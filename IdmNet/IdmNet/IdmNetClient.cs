using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Xml;
using IdmNet.Models;
using IdmNet.SoapModels;

// ReSharper disable InconsistentNaming

namespace IdmNet
{
    /// <summary>
    /// This is the primary class in the IdmNet assembly.  It is the .NET client used to perform CRUD operations on
    /// objects/resources in the Identity Manager Service database.
    /// </summary>
    public class IdmNetClient
    {
        private readonly SearchClient _searchClient;
        private readonly ResourceFactoryClient _factoryClient;
        private readonly ResourceClient _resourceClient;

        /// <summary>
        /// Primary constructor for the IdmNetClient.  Though this is public and can be called, the normal thing to
        /// do is to use IdmNetClientFactory.BuildClient().  This is available in case you want to build the client
        /// based on different assumptions made by the factory builder.  For example, if you wanted to use a different
        /// client credentials mechanism, WCF binding, or endpoints
        /// </summary>
        /// <param name="searchClient">
        /// This is the SOAP client used to connect to Identity Manager for search functionality (WS-Enumeration - 
        /// Enumerate and Pull operations)
        /// </param>
        /// <param name="factoryClient">
        /// This is the SOAP client used to create new objects/resources in Identity Manager (WS-Transfer - Create 
        /// operation)
        /// </param>
        /// <param name="resourceClient">
        /// This is the SOAP client used to modify existing objects/resources in Identity Manager 
        /// </param>
        public IdmNetClient(SearchClient searchClient, ResourceFactoryClient factoryClient, ResourceClient resourceClient)
        {
            _searchClient = searchClient;
            _factoryClient = factoryClient;
            _resourceClient = resourceClient;
        }

        /// <summary>
        /// Search the Identity Manager  (async await)
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IdmResource>> SearchAsync(SearchCriteria criteria, int pageSize = 50)
        {
            if (criteria.Selection.Contains("*"))
            {
                await SetupGetStar(criteria);
            }

            PullInfo pullInfo = await PreparePagedSearchAsync(criteria, pageSize);

            // Pull all results
            var results = new List<IdmResource>();
            PagedSearchResults pagedResults;
            PagingContext pagingContext = pullInfo.PagingContext;
            do
            {
                pagedResults = await PullAsync(pageSize, pagingContext);
                results.AddRange(pagedResults.Results);
            } while (pagedResults.EndOfSequence == null);

            return results;
        }

        /// <summary>
        /// Set up a Paged search
        /// </summary>
        /// <param name="criteria">Search criteria</param>
        /// <param name="pageSize">number of records to return</param>
        /// <returns></returns>
        public async Task<PullInfo> PreparePagedSearchAsync(SearchCriteria criteria, int pageSize)
        {
            var enumerateResponseMessage = await EnumerateSearch(criteria);

            var pullInfo = new PullInfo
            {
                PageSize = pageSize,
                EnumerateResponse =
                    enumerateResponseMessage.GetBody<EnumerateResponse>(new SoapXmlSerializer(typeof(EnumerateResponse))),
            };
            return pullInfo;
        }

        /// <summary>
        /// Pull resources from Identity Manager
        /// </summary>
        /// <param name="pageSize">Maximum number of records to return</param>
        /// <param name="pagingContext">Information regarding which records to pull</param>
        /// <returns>Paged search results</returns>
        /// <exception cref="SoapFaultException"></exception>
        public async Task<PagedSearchResults> PullAsync(int pageSize, PagingContext pagingContext)
        {
            var pullMessage = Message.CreateMessage(
                MessageVersion.Default,
                "http://schemas.xmlsoap.org/ws/2004/09/enumeration/Pull",
                new Pull
                {
                    PagingContext = pagingContext,
                    MaxElements = pageSize,
                    PullAdjustment =
                        new PullAdjustment { StartingIndex = pagingContext.CurrentIndex, EnumerationDirection = "Forwards" }
                },
                new SoapXmlSerializer(typeof(Pull)));

            var pullResponseMessage = await _searchClient.PullAsync(pullMessage);


            if (pullResponseMessage.IsFault)
                throw new SoapFaultException("Pull Fault: " + pullResponseMessage);

            return ConvertPullResponseToPagedSearchResults(pagingContext, pullResponseMessage);
        }

        /// <summary>
        /// Get an object by its ID from Identity Manager (async await)
        /// </summary>
        /// <param name="objectID">Resource ID for the object to retrieve</param>
        /// <param name="selection"></param>
        /// <returns>Resource matching ObjectID</returns>
        public async Task<IdmResource> GetAsync(string objectID, List<string> selection)
        {
            if (String.IsNullOrWhiteSpace(objectID))
                throw new ArgumentNullException("objectID");

            var getRequestMsg = PrepareGetRequestMsg(objectID, selection);

            Message getResponseMsg = await _resourceClient.GetAsync(getRequestMsg);

            if (getResponseMsg.IsFault)
                throw new SoapFaultException("Get Fault: " + getResponseMsg);

            var resource = ConvertGetResponseToIdmResource(getResponseMsg);

            return resource;
        }

        /// <summary>
        /// Get the number of Identity Manager resources that match the given XPath Filter.
        /// </summary>
        /// <param name="filter">Search filter</param>
        /// <returns>Number of matching resources</returns>
        public async Task<int> GetCountAsync(string filter)
        {
            var criteria = new SearchCriteria { Filter = new Filter { Query = filter } };
            Message enumerateResponseMessage = await EnumerateSearch(criteria);
            var response =
                enumerateResponseMessage.GetBody<EnumerateResponse>(new SoapXmlSerializer(typeof(EnumerateResponse)));

            return response.EnumerationDetail.Count;
        }

        /// <summary>
        /// Create Object/Resource in Identity Manager Service  (async await)
        /// </summary>
        /// <param name="resource">Resource to be created</param>
        /// <returns>Resource with its newly assigned ObjectID</returns>
        public async Task<IdmResource> PostAsync(IdmResource resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource");

            var createRequestMessage = BuildCreateRequestMessage(resource);

            // Add the required header for the Create action
            createRequestMessage.Headers.Add(MessageHeader.CreateHeader("IdentityManagementOperation", SoapConstants.DirectoryAccess, null, true));


            Message addResponseMsg = await _factoryClient.CreateAsync(createRequestMessage);

            if (addResponseMsg.IsFault)
                throw new SoapFaultException("Create Fault: " + addResponseMsg);

            // Deserialize the Add response
            ResourceCreated resourceCreatedObject = addResponseMsg.GetBody<ResourceCreated>(new SoapXmlSerializer(typeof(ResourceCreated)));

            resource.ObjectID = resourceCreatedObject.EndpointReference.ReferenceProperties.ResourceReferenceProperty.Value;

            if (resource.ObjectID.StartsWith("urn:uuid:"))
                resource.ObjectID = resource.ObjectID.Substring(9);

            return resource;
        }

        /// <summary>
        /// Delete an object in the Identity Manager service (async await)
        /// </summary>
        /// <param name="objectID">Resource ID for the object to be deleted</param>
        /// <returns></returns>
        public async Task<Message> DeleteAsync(string objectID)
        {
            if (String.IsNullOrWhiteSpace(objectID))
                throw new ArgumentNullException("objectID");

            Message deleteRequestMsg = Message.CreateMessage(MessageVersion.Default, SoapConstants.DeleteAction);

            deleteRequestMsg.Headers.Add(MessageHeader.CreateHeader("ResourceReferenceProperty", SoapConstants.RmNamespace, objectID));

            Message deleteResponseMsg = await _resourceClient.DeleteAsync(deleteRequestMsg);
            if (deleteResponseMsg.IsFault)
                throw new SoapFaultException("Delete Fault: " + deleteResponseMsg);

            return deleteResponseMsg;
        }

        /// <summary>
        /// Add a value to a multi-valued attribute in the Identity Manager service  (async await)
        /// </summary>
        /// <remarks>
        /// While all attributes in an IdmResource are technically multi-valued, this method only works on attributes
        /// that are marked as multi-valued in the Identity Manager service.
        /// </remarks>
        /// <param name="objectID">Resource ID for the object containing the multi-valued attribute</param>
        /// <param name="attrName">Name of the Multi-Valued attribute to which a value will be added</param>
        /// <param name="attrValue">Value to be added to the Multi-Valued attribute</param>
        /// <returns>Task (async/await) of the asynchronous operation</returns>
        public async Task<Message> AddValueAsync(string objectID, string attrName, string attrValue)
        {
            return await PutAttribute(objectID, attrName, attrValue, ModeType.Add);
        }

        /// <summary>
        /// Remove a value from a multi-valued attribute in the Identity Manager service (async await)
        /// </summary>
        /// <remarks>
        /// While all attributes in an IdmResource are technically multi-valued, this method only works on attributes
        /// that are marked as multi-valued in the Identity Manager service.
        /// </remarks>
        /// <param name="objectID">Resource ID for the object containing the multi-valued attribute</param>
        /// <param name="attrName">Name of the Multi-Valued attribute from which a value will be removed</param>
        /// <param name="attrValue">Value to be removed from the Multi-Valued attribute</param>
        /// <returns>Task (async/await) of the asynchronous operation</returns>
        public async Task<Message> RemoveValueAsync(string objectID, string attrName, string attrValue)
        {
            return await PutAttribute(objectID, attrName, attrValue, ModeType.Delete);
        }

        /// <summary>
        /// Replace/Set the value for a single-valued attribute in the Identity Manager service (async await)
        /// </summary>
        /// <remarks>
        /// While all attributes in an IdmResource are technically multi-valued, this method only works on attributes
        /// that are marked as single-valued in the Identity Manager service.
        /// </remarks>
        /// <param name="objectID">Resource ID for the object containing the single-valued attribute</param>
        /// <param name="attrName">Name of the Single-Valued attribute which will have its value set/replaced</param>
        /// <param name="attrValue">Value to be set for the Single-Valued attribute</param>
        /// <returns>Task (async/await) of the asynchronous operation</returns>
        public async Task<Message> ReplaceValueAsync(string objectID, string attrName, string attrValue)
        {
            return await PutAttribute(objectID, attrName, attrValue, ModeType.Replace);
        }

        /// <summary>
        /// Make multiple changes to a particular Identity Manager service object/resource (async await)
        /// </summary>
        /// <param name="objectID">Resource ID for the object containing the attributes to be modified</param>
        /// <param name="changes">
        /// Set of changes (Multi-valued "Adds/Removes and Single-valued "Replaces" to be made for the single object
        /// </param>
        /// <returns>Task (async/await) of the asynchronous operation</returns>
        public async Task<Message> ChangeMultipleAttrbutes(string objectID, Change[] changes)
        {
            var modifyRequest = new ModifyRequest {Change = changes};

            return await PutAsync(objectID, modifyRequest);
        }

        /// <summary>
        /// Get the Schema associated with a particular object type
        /// </summary>
        /// <param name="objectType">Name of the object for which the schema should be retrieved</param>
        /// <returns>A fully populated ObjectTypeDescription object, including bindings for attributes</returns>
        public async Task<ObjectTypeDescription> GetSchemaAsync(string objectType)
        {
            var result = await GetObjectTypeDescription(objectType);
            result.BindingDescriptions = new List<BindingDescription>();

            await AddBindingDescriptions(result);

            return result;

        }





        private async Task AddBindingDescriptions(ObjectTypeDescription result)
        {
            var bindingCriteria = new SearchCriteria(String.Format("/BindingDescription[BoundObjectType='{0}']", result.ObjectID))
            {
                Selection =
                    new List<string>
                    {
                        "DisplayName",
                        "CreatedTime",
                        "Creator",
                        "Description",
                        "Name",
                        "ObjectID",
                        "ObjectType",
                        "ResourceTime",
                        "UsageKeyword",
                        "BoundObjectType",
                        "BoundAttributeType",
                        "Required"
                    }
            };

            IEnumerable<IdmResource> bindingResources = await SearchAsync(bindingCriteria);
            foreach (var bindingResource in bindingResources)
            {
                var binding = new BindingDescription(bindingResource);


                var attrTypeResource = await GetAsync(binding.BoundAttributeType.ObjectID,
                    new List<string>
                    {
                        "DisplayName",
                        "CreatedTime",
                        "Creator",
                        "Description",
                        "Name",
                        "ObjectID",
                        "ObjectType",
                        "ResourceTime",
                        "UsageKeyword",
                        "DataType",
                        "Multivalued"
                    }
                    );

                var attrType = new AttributeTypeDescription(attrTypeResource);
                binding.BoundAttributeType = attrType;



                result.BindingDescriptions.Add(binding);
            }
        }

        private async Task<ObjectTypeDescription> GetObjectTypeDescription(string objectType)
        {
            var criteria = new SearchCriteria(String.Format("/ObjectTypeDescription[Name='{0}']", objectType))
            {
                Selection =
                    new List<string>
                    {
                        "DisplayName",
                        "CreatedTime",
                        "Creator",
                        "Description",
                        "Name",
                        "ObjectID",
                        "ObjectType",
                        "ResourceTime",
                        "UsageKeyword"
                    }
            };


            IEnumerable<IdmResource> resources = await SearchAsync(criteria);
            var result = new ObjectTypeDescription(resources.FirstOrDefault());
            return result;
        }

        private static IdmResource ConvertGetResponseToIdmResource(Message getResponseMsg)
        {
            BaseObjectSearchResponse getResponseObj =
                getResponseMsg.GetBody<BaseObjectSearchResponse>(new SoapXmlSerializer(typeof(BaseObjectSearchResponse)));

            var resource = new IdmResource();

            foreach (XmlNode partialAttribute in getResponseObj.PartialAttribute)
                foreach (XmlNode attribute in partialAttribute.ChildNodes)
                    BuildAttribute(attribute, resource);
            return resource;
        }

        private static Message PrepareGetRequestMsg(string objectID, List<string> selection)
        {
            var getRequest = new BaseObjectSearchRequest { AttributeType = IdmNetUtils.EnsureDefaultSelectionPresent(selection) };

            // Create the Get request message
            Message getRequestMsg = Message.CreateMessage(MessageVersion.Default,
                SoapConstants.GetAction,
                getRequest,
                new SoapXmlSerializer(typeof(BaseObjectSearchRequest))
                );

            // Add the required headers for the Get request
            getRequestMsg.Headers.Add(MessageHeader.CreateHeader("ResourceReferenceProperty", SoapConstants.RmNamespace,
                objectID));
            getRequestMsg.Headers.Add(MessageHeader.CreateHeader("IdentityManagementOperation",
                SoapConstants.DirectoryAccess, null, true));
            return getRequestMsg;
        }

        private async Task SetupGetStar(SearchCriteria criteria)
        {
            criteria.Selection = new List<string> { "ObjectType" };
            PullInfo objectTypePullInfo = await PreparePagedSearchAsync(criteria, 1);
            PagingContext objectTypePagingContext = objectTypePullInfo.PagingContext;
            PagedSearchResults objectTypeResults = await PullAsync(1, objectTypePagingContext);
            string objectType = objectTypeResults.Results[0].ObjectType;

            var schema = await GetSchemaAsync(objectType);
            criteria.Selection.Clear();
            foreach (var bindingDescription in schema.BindingDescriptions)
            {
                criteria.Selection.Add(bindingDescription.BoundAttributeType.Name);
            }
        }

        private async Task<Message> EnumerateSearch(SearchCriteria criteria)
        {
            var enumerateMessage = Message.CreateMessage(
                MessageVersion.Default,
                SoapConstants.EnumerateAction,
                criteria,
                new SoapXmlSerializer(typeof(SearchCriteria)));

            enumerateMessage.Headers.Add(MessageHeader.CreateHeader("IncludeCount", "http://schemas.microsoft.com/2006/11/ResourceManagement", null, false));
            var enumerateResponseMessage = await _searchClient.EnumerateAsync(enumerateMessage);


            // Check for enumerate fault
            if (enumerateResponseMessage.IsFault)
                throw new SoapFaultException("Enumerate Fault: " + enumerateResponseMessage);
            return enumerateResponseMessage;
        }

        private static PagedSearchResults ConvertPullResponseToPagedSearchResults(PagingContext pagingContext,
            Message pullResponseMessage)
        {
            var pagedSearchResults =
                pullResponseMessage.GetBody<PagedSearchResults>(new SoapXmlSerializer(typeof(PagedSearchResults)));
            if (pagedSearchResults.Items != null)
            {
                var xmlNodes = (XmlNode[])pagedSearchResults.Items;
                var resources = xmlNodes.Select(BuildResource).ToArray();
                pagedSearchResults.Results.AddRange(resources);
                pagingContext.CurrentIndex += xmlNodes.Length;
            }
            return pagedSearchResults;
        }

        private static IdmResource BuildResource(XmlNode xmlNode)
        {
            var resource = new IdmResource();

            foreach (XmlNode attribute in xmlNode.ChildNodes)
                BuildAttribute(attribute, resource);

            return resource;
        }

        private static void BuildAttribute(XmlNode attribute, IdmResource resource)
        {
            string name = attribute.LocalName;
            string val = attribute.InnerText;

            if (val.StartsWith("urn:uuid:"))
                val = val.Substring(9);

            var attr = resource.GetAttr(name);
            if (attr != null)
                attr.Values.Add(val);
            else
                resource.Attributes.Add(new IdmAttribute { Name = name, Value = val });
        }

        private static Message BuildCreateRequestMessage(IdmResource resource)
        {
            var factoryRequest = BuildFactoryRequest(resource);

            var createRequestMessage = CreateSoapMessage(factoryRequest);

            return createRequestMessage;
        }

        private static Message CreateSoapMessage(AddRequest factoryRequest)
        {
            var createRequestMessage = Message.CreateMessage(MessageVersion.Default,
                SoapConstants.CreateAction,
                factoryRequest,
                new SoapXmlSerializer(typeof(AddRequest))
                );
            return createRequestMessage;
        }

        private static AddRequest BuildFactoryRequest(IdmResource resource)
        {
            var values = from attribute in resource.Attributes
                         from val in attribute.Values
                         select new AttributeTypeAndValue(attribute.Name, val);
            var factoryRequest = new AddRequest { AttributeTypeAndValue = values.ToArray() };
            return factoryRequest;
        }

        private async Task<Message> PutAttribute(string objectID, string attrName, string attrValue, ModeType modeType)
        {
            ModifyRequest modifyRequest = new ModifyRequest();
            Change changeRemoveAttribute = new Change(modeType, attrName, attrValue);
            modifyRequest.Change = new[] { changeRemoveAttribute };

            return await PutAsync(objectID, modifyRequest);
        }

        private async Task<Message> PutAsync(string objectID, ModifyRequest modifyRequest)
        {
            // Create the Put request messsage
            Message putRequestMsg = Message.CreateMessage(MessageVersion.Default,
                SoapConstants.PutAction,
                modifyRequest,
                new SoapXmlSerializer(typeof(ModifyRequest))
                );

            // Add the ResourceReferenceProperty header for the Put request
            putRequestMsg.Headers.Add(MessageHeader.CreateHeader("ResourceReferenceProperty", SoapConstants.RmNamespace,
                objectID));
            putRequestMsg.Headers.Add(MessageHeader.CreateHeader("IdentityManagementOperation", SoapConstants.DirectoryAccess,
                null, true));

            Message putResponseMsg = await _resourceClient.PutAsync(putRequestMsg);

            if (putResponseMsg.IsFault)
                throw new SoapFaultException("Put Fault: " + putResponseMsg);

            return putResponseMsg;
        }
    }
}

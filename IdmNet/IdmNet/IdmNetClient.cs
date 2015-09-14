using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Xml;
using IdmNet.Models;
using IdmNet.SoapModels;
// ReSharper disable PossibleNullReferenceException

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
            var results = new List<IdmResource>();

            try
            {
                if (criteria.Selection.Contains("*"))
                {
                    // Can throw the ArgumentOutOfRangeException if there are no results, in which case just return the empty list
                    await SetupGetStar(criteria);
                }

                PullInfo pullInfo = await PreparePagedSearchAsync(criteria, pageSize);

                // Pull all results
                PagedSearchResults pagedResults;
                PagingContext pagingContext = pullInfo.PagingContext;
                do
                {
                    pagedResults = await GetPagedResultsAsync(pageSize, pagingContext);
                    results.AddRange(pagedResults.Results);
                } while (pagedResults.EndOfSequence == null);
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            return results;
        }

        /// <summary>
        /// Search the Identity Manager  (async await)
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<PagedSearchResults> GetPagedResultsAsync(SearchCriteria criteria, int pageSize = 50)
        {
            if (criteria.Selection.Contains("*"))
            {
                await SetupGetStar(criteria);
            }

            PullInfo pullInfo = await PreparePagedSearchAsync(criteria, pageSize);

            // Pull all results
            PagingContext pagingContext = pullInfo.PagingContext;
            return await GetPagedResultsAsync(pageSize, pagingContext);
        }

        private async Task<PullInfo> PreparePagedSearchAsync(SearchCriteria criteria, int pageSize)
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
        public async Task<PagedSearchResults> GetPagedResultsAsync(int pageSize, PagingContext pagingContext)
        {
            var pullMessage = BuildPullMessage(pageSize, pagingContext);

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
                throw new ArgumentNullException(nameof(objectID));

            if (selection != null && selection.Contains("*"))
            {
                IdmResource baseResource = await GetAsync(objectID, new List<string> {"ObjectType"});
                selection = await GetAttributeNamesForObjectType(baseResource.ObjectType);
            }

            var getRequestMsg = PrepareGetRequestMsg(objectID, selection);
            Message getResponseMsg = await _resourceClient.GetAsync(getRequestMsg);

            if (getResponseMsg.IsFault)
            {
                var xml = getResponseMsg.ToString();
                if (xml != null && xml.Contains("The target Resource does not exist"))
                {
                    throw new KeyNotFoundException("ObjectID " + objectID + " not found");
                }
                // 
                throw new SoapFaultException("Get Fault: " + getResponseMsg);
            }
                

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
        public async Task<Message> CreateAsync(IdmResource resource)
        {
            if (resource == null) throw new ArgumentNullException(nameof(resource));

            var creationRequestMsg = BuildCreationRequestMessage(resource);

            AddIdmHeaderToCreationMessage(creationRequestMsg);

            Message creationResponseMsg = await _factoryClient.CreateAsync(creationRequestMsg);

            if (creationResponseMsg.IsFault) throw new SoapFaultException("Create Fault: " + creationResponseMsg);

            return creationResponseMsg;
        }

        /// <summary>
        /// Delete an object in the Identity Manager service (async await)
        /// </summary>
        /// <param name="objectID">Resource ID for the object to be deleted</param>
        /// <returns></returns>
        public async Task<Message> DeleteAsync(string objectID)
        {
            if (string.IsNullOrWhiteSpace(objectID))
                throw new ArgumentNullException(nameof(objectID));

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
        public async Task<Schema> GetSchemaAsync(string objectType)
        {
            var result = await BuildSchemaObject(objectType);
            result.BindingDescriptions = new List<BindingDescription>();

            await AddBindingDescriptions(result);

            return result;

        }

        /// <summary>
        /// Get the ObjectID for a newly created resource from the response message
        /// </summary>
        /// <param name="resourceCreationResponseMessage">Response message from the CreateAsync method</param>
        /// <returns>New object id</returns>
        public string GetNewObjectId(Message resourceCreationResponseMessage)
        {
            var resourceCreationResponse = DeserializeCreationResponse(resourceCreationResponseMessage);
            return resourceCreationResponse.EndpointReference.ReferenceProperties.ResourceReferenceProperty.Value.Substring(9);
        }

        /// <summary>
        /// Approve or reject a particular request
        /// </summary>
        /// <param name="pendingApproval">A pending approval object - EndpointAddress and WorkflowInstance must be populated.</param>
        /// <param name="approve">If true, approve the request, otherwise reject</param>
        /// <returns>SOAP Message from the resulting Approval Response created.</returns>
        public async Task<Message> ApproveOrRejectAsync(Approval pendingApproval, string reason, bool approve)
        {
            if (pendingApproval == null) throw new ArgumentNullException(nameof(pendingApproval));

            string approvalEndpoint = "";
            foreach (string endpointAddress in pendingApproval.EndpointAddress)
            {
                if (endpointAddress.StartsWith("http:"))
                    approvalEndpoint = endpointAddress;
            }

            var approvalResponse = new ApprovalResponseSoapModel(
                pendingApproval.ObjectID,
                approve ? "Approved" : "Rejected",
                reason);

            var soapBinding = new IdmSoapBinding();
            var factoryEndpoint = new EndpointAddress(new Uri(approvalEndpoint), _factoryClient.Endpoint.Address.Identity);
            var factoryClient = new ResourceFactoryClient(soapBinding, factoryEndpoint);
            factoryClient.ClientCredentials.Windows.ClientCredential = _factoryClient.ClientCredentials.Windows.ClientCredential;

            Message approvalResponseMessage = Message.CreateMessage(
                MessageVersion.Default,
                "http://schemas.xmlsoap.org/ws/2004/09/transfer/Create",
                approvalResponse,
                new SoapXmlSerializer(typeof(ApprovalResponseSoapModel)));

            approvalResponseMessage.Headers.Add(new ContextHeader(pendingApproval.WorkflowInstance.ObjectID)); 

            Message creationResponseMsg = await factoryClient.CreateAsync(approvalResponseMessage);

            if (creationResponseMsg.IsFault)
                throw new SoapFaultException("Create Fault: " + creationResponseMsg);

            return creationResponseMsg;
        }

        /// <summary>
        /// Approve a particular request
        /// </summary>
        /// <param name="pendingApproval">A pending approval object - EndpointAddress and WorkflowInstance must be populated.</param>
        /// <returns>SOAP Message from the resulting Approval Response created.</returns>
        public async Task<Message> ApproveAsync(Approval pendingApproval)
        {
            return await ApproveOrRejectAsync(pendingApproval, "because I said so", true);
        }

        /// <summary>
        /// Reject a particular request
        /// </summary>
        /// <param name="pendingApproval">A pending approval object - EndpointAddress and WorkflowInstance must be populated.</param>
        /// <returns>SOAP Message from the resulting Approval Response created.</returns>
        public async Task<Message> RejectAsync(Approval pendingApproval)
        {
            return await ApproveOrRejectAsync(pendingApproval, "because I said so", false);
        }

        /// <summary>
        /// Returns the Approval object for a given request
        /// </summary>
        /// <param name="requestObjectId">ObjectID for a given request that should have an approval associated with it.</param>
        /// <returns>An Approval object with both "EndpointAddress" and "WorkflowInstance" populated, or NULL if no Approvals exist for a given request</returns>
        public async Task<List<Approval>> GetApprovalsForRequest(string requestObjectId)
        {
            var searchApprovals =
                await
                    SearchAsync(new SearchCriteria($"/Approval[Request = '{requestObjectId}']")
                    {
                        Selection = new List<string> {"EndpointAddress", "WorkflowInstance"}
                    });

            var approvals = from a in searchApprovals
                select new Approval(a);

            return approvals.ToList();
        }




        private async Task AddBindingDescriptions(Schema result)
        {
            var bindingCriteria = new SearchCriteria($"/BindingDescription[BoundObjectType='{result.ObjectID}']")
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

        private async Task<Schema> BuildSchemaObject(string objectType)
        {
            var criteria = new SearchCriteria($"/ObjectTypeDescription[Name='{objectType}']")
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
            var result = new Schema(resources.FirstOrDefault());
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
            PagedSearchResults objectTypeResults = await GetPagedResultsAsync(1, objectTypePagingContext);
            string objectType = objectTypeResults.Results[0].ObjectType;

            criteria.Selection = await GetAttributeNamesForObjectType(objectType);
        }

        private async Task<List<string>> GetAttributeNamesForObjectType(string objectType)
        {
            var schema = await GetSchemaAsync(objectType);
            var selectList =
                schema.BindingDescriptions.Select(bindingDescription => bindingDescription.BoundAttributeType.Name).ToList();
            return selectList;
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

        private static Message BuildCreationRequestMessage(IdmResource resource)
        {
            var factoryRequest = BuildFactoryRequest(resource);

            var createRequestMessage = CreateSoapFactoryCreateMessage(factoryRequest);

            return createRequestMessage;
        }

        private static Message CreateSoapFactoryCreateMessage(AddRequest factoryRequest)
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

            var responseStr = putResponseMsg.ToString();
            if (responseStr != null && (putResponseMsg.IsFault && !(responseStr.Contains("AuthorizationRequiredFault"))))
                throw new SoapFaultException("Put Fault: " + putResponseMsg);

            return putResponseMsg;
        }

        private static Message BuildPullMessage(int pageSize, PagingContext pagingContext)
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
            return pullMessage;
        }

        private static void AddIdmHeaderToCreationMessage(Message createRequestMessage)
        {
            createRequestMessage.Headers.Add(MessageHeader.CreateHeader("IdentityManagementOperation",
                SoapConstants.DirectoryAccess, null, true));
        }

        private static ResourceCreated DeserializeCreationResponse(Message creationResponseMsg)
        {
            ResourceCreated resourceCreatedObject =
                creationResponseMsg.GetBody<ResourceCreated>(new SoapXmlSerializer(typeof(ResourceCreated)));
            return resourceCreatedObject;
        }

        /// <summary>
        /// Returns the ResourceReferenceProperty (eg. Approval ObjectID) associated with a particular message returned
        /// from an create/update-type operation
        /// </summary>
        /// <param name="soapMessageString">The SOAP message in a string format (msg.ToString())</param>
        /// <returns>The ObjectID of the associated resource/Approval, otherwise NULL</returns>
        /// <exception cref="NotImplementedException"></exception>
        public string GetResourceReferenceProperty(string soapMessageString)
        {
            var searchValue =
                @"<ResourceReferenceProperty xmlns=""http://schemas.microsoft.com/2006/11/ResourceManagement"">urn:uuid:";
            int startIndex =
                soapMessageString.IndexOf(searchValue, StringComparison.Ordinal) + searchValue.Length;
            int endIndex = soapMessageString.IndexOf("</ResourceReferenceProperty>", StringComparison.Ordinal);

            var returnValue = soapMessageString.Substring(startIndex, endIndex - startIndex);

            return returnValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Xml;

namespace IdmNet
{
    public class IdmNetClient
    {
        private readonly SearchClient _search;
        private readonly ResourceFactoryClient _factory;

        public IdmNetClient(SearchClient search, ResourceFactoryClient factory)
        {
            _search = search;
            _factory = factory;
        }

        public async Task<IEnumerable<IdmResource>> SearchAsync(SearchCriteria criteria)
        {
            var pullInfo = await EnumerateAndPreparePull(criteria);

            // Pull all results
            PullResponse pullResponseObj;
            var results = new List<IdmResource>();
            EnumerationContext enumerationContext = pullInfo.EnumerationContext;
            do
            {
                pullResponseObj = await Pull(criteria.PageSize, enumerationContext, results);
            } while (pullResponseObj.EndOfSequence == null);

            Sort(results, criteria);

            return results;
        }

        private static void Sort(List<IdmResource> results, SearchCriteria criteria)
        {
            string attrName = criteria.SortAttribute;
            if (attrName != null)
            {
                results.Sort(
                    (res1, res2) =>
                    {
                        var negateIfNeeded = ((criteria.SortDecending) ? -1 : 1);
                        var val1 = res1[attrName].Value ?? "";
                        var val2 = res2[attrName].Value ?? "";
                        var compareResult = String.Compare(val1.ToLower(), val2.ToLower(),
                            StringComparison.Ordinal)*negateIfNeeded;
                        return compareResult;
                    }
                    );
            }
        }

        private async Task<PullInfo> EnumerateAndPreparePull(SearchCriteria criteria)
        {
            // Enumerate request
            var enumerateMessage = Message.CreateMessage(
                MessageVersion.Default,
                SoapConstants.EnumerateAction,
                new Enumerate
                {
                    Filter = new Filter(criteria.XPath),
                    Selection = criteria.Attributes,
                    Sorting = new Sorting { SortingAttribute = new SortingAttribute { AttributeName = criteria.SortAttribute, Ascending = !criteria.SortDecending } }
                },
                new SoapXmlSerializer(typeof(Enumerate)));
            Trace.WriteLine(enumerateMessage);
            var enumerateResponseMessage = await _search.EnumerateAsync(enumerateMessage);


            // Check for enumerate fault
            if (enumerateResponseMessage.IsFault)
                throw new Exception("Enumerate Fault: " + enumerateResponseMessage);


            // Prepare first Pull
            if (criteria.PageSize == 0)
                criteria.PageSize = int.MaxValue;


            var pullInfo = new PullInfo
            {
                PageSize = criteria.PageSize,
                EnumerateResponse =
                    enumerateResponseMessage.GetBody<EnumerateResponse>(new SoapXmlSerializer(typeof(EnumerateResponse))),
            };
            return pullInfo;
        }

        private async Task<PullResponse> Pull(int pageSize, EnumerationContext enumerationContext, List<IdmResource> results)
        {
            var pullMessage = Message.CreateMessage(
                MessageVersion.Default,
                "http://schemas.xmlsoap.org/ws/2004/09/enumeration/Pull",
                new Pull
                {
                    EnumerationContext = enumerationContext,
                    MaxElements = pageSize,
                    PullAdjustment =
                        new PullAdjustment { StartingIndex = enumerationContext.CurrentIndex, EnumerationDirection = "Forwards" }
                },
                new SoapXmlSerializer(typeof(Pull)));

            var pullResponseMessage = await _search.PullAsync(pullMessage);


            // Check for Pull fault
            if (pullResponseMessage.IsFault)
                throw new Exception("Pull Fault: " + pullResponseMessage);


            // Get Resources from Pull response
            var pullResponseObj = pullResponseMessage.GetBody<PullResponse>(new SoapXmlSerializer(typeof(PullResponse)));
            if (pullResponseObj.Items != null)
            {
                var xmlNodes = (XmlNode[])pullResponseObj.Items;
                results.AddRange(xmlNodes.Select(BuildResource));

                enumerationContext.CurrentIndex += xmlNodes.Length;
            }
            return pullResponseObj;
        }

        private static IdmResource BuildResource(XmlNode xmlNode)
        {
            var resource = new IdmResource();

            foreach (XmlNode attribute in xmlNode.ChildNodes)
            {
                string name = attribute.LocalName;
                string val = attribute.InnerText;

                if (val.StartsWith("urn:uuid:"))
                    val = val.Substring(9);

                var attr = resource.GetAttr(name);
                if (attr != null)
                    attr.Values.Add(val);
                else
                    resource.Attributes.Add(new IdmAttribute{ Name = name, Value = val });
            }
            return resource;
        }


        // TODO 007: Achieve complet code coverage for Create
        public async Task<IdmResource> CreateAsync(IdmResource resource)
        {
            if (resource == null)
                throw new ArgumentNullException("resource");

            var createRequestMessage = BuildCreateRequestMessage(resource);

            // Add the required header for the Create action
            createRequestMessage.Headers.Add(MessageHeader.CreateHeader("IdentityManagementOperation", SoapConstants.DirectoryAccess, null, true));


            Message addResponseMsg = await _factory.CreateAsync(createRequestMessage);

            if (addResponseMsg.IsFault)
                throw new Exception("Create Fault: " + addResponseMsg);

            // Deserialize the Add response
            ResourceCreated resourceCreatedObject = addResponseMsg.GetBody<ResourceCreated>(new SoapXmlSerializer(typeof(ResourceCreated)));

            resource.ObjectID = resourceCreatedObject.EndpointReference.ReferenceProperties.ResourceReferenceProperty.Value;

            if (resource.ObjectID.StartsWith("urn:uuid:"))
                resource.ObjectID = resource.ObjectID.Substring(9);

            return resource;
        }

        private static Message BuildCreateRequestMessage(IdmResource resource)
        {
            // Create the request object
            var values = from attribute in resource.Attributes
                from val in attribute.Values
                select new AttributeTypeAndValue(attribute.Name, val);
            var factoryRequest = new AddRequest {AttributeTypeAndValue = values.ToArray()};

            // Create the SOAP message
            var createRequestMessage = Message.CreateMessage(MessageVersion.Default,
                SoapConstants.CreateAction,
                factoryRequest,
                new SoapXmlSerializer(typeof (AddRequest))
                );

            return createRequestMessage;
        }
    }
}

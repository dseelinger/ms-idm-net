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
        private readonly SearchClient _searchClient;

        public IdmNetClient(SearchClient searchClient)
        {
            _searchClient = searchClient;
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
            var enumerateResponseMessage = await _searchClient.EnumerateAsync(enumerateMessage);


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

            var pullResponseMessage = await _searchClient.PullAsync(pullMessage);


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

        // TODO 001: Create Objects in FIM
        //public Task<IdmResource> CreateAsync(IdmResource newUser)
        //{
        //    return null;
        //}
    }
}

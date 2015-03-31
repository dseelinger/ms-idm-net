using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Xml;

namespace IdmNet
{
    public class IdmNet
    {
        private readonly SearchClient _searchClient;

        public IdmNet(SearchClient searchClient)
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

            return results;
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
                string key = attribute.LocalName;
                string val = attribute.InnerText;

                // TODO: Fix this for the "new" IdmResource
                if (resource.ContainsKey(key))
                    resource[key].Add(val);
                else
                    resource.Add(key, new List<string> { val.Replace("urn:uuid:", "") });
            }
            return resource;
        }


    }
}

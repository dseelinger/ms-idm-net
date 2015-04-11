using System.Xml.Serialization;

namespace IdmNet
{
    public class PullInfo
    {
        public EnumerateResponse EnumerateResponse { get; set; }
        public int PageSize { get; set; }
        public EnumerationContext EnumerationContext { get { return EnumerateResponse.EnumerationContext; } }
    }


    [XmlRoot(Namespace = SoapConstants.EnumerateAction, IsNullable = false)]
    public class Filter
    {
        public Filter()
        {
            Dialect = "http://schemas.microsoft.com/2006/11/XPathFilterDialect";
        }

        public Filter(string query)
            : this()
        {
            Query = query;
        }

        [XmlAttribute(AttributeName = "Dialect", DataType = "anyURI")]
        public string Dialect { get; set; }

        [XmlText]
        public string Query { get; set; }
    }



    public class PullAdjustment
    {
        public PullAdjustment()
        {
            EnumerationDirection = "Forwards";
        }

        public string EnumerationDirection { get; set; }
        public int StartingIndex { get; set; }
    }

    public class EnumerationContext
    {
        [XmlElement(Namespace = SoapConstants.RmNamespace)]
        public int CurrentIndex { get; set; }

        [XmlElement(Namespace = SoapConstants.RmNamespace)]
        public string EnumerationDirection { get; set; }

        [XmlElement(Namespace = SoapConstants.RmNamespace)]
        public string Expires { get; set; }

        [XmlElement(Namespace = SoapConstants.RmNamespace)]
        public string Filter { get; set; }

        [XmlArray(Namespace = SoapConstants.RmNamespace)]
        public string[] Selection { get; set; }
    }


    [XmlRoot(ElementName = "EnumerationDetail")]
    public class EnumerationCount
    {
        [XmlElement]
        public int Count { get; set; }
    }


    [XmlRoot(Namespace = SoapConstants.EnumerationNamespace)]
    public class EnumerateResponse
    {
        public EnumerationContext EnumerationContext { get; set; }

        [XmlElement(ElementName = "EnumerationDetail", Namespace = SoapConstants.RmNamespace)]
        public EnumerationCount EnumerationCount { get; set; }

        public string Expires { get; set; }
    }



    [XmlRoot(Namespace = SoapConstants.EnumerationNamespace)]
    public class Pull
    {
        public EnumerationContext EnumerationContext { get; set; }

        public int MaxElements { get; set; }

        public PullAdjustment PullAdjustment { get; set; }
    }



    [XmlRoot(Namespace = SoapConstants.EnumerationNamespace)]
    public class PullResponse
    {
        public object EndOfSequence { get; set; }
        public EnumerationContext EnumerationContext { get; set; }
        public object Items { get; set; }
    }


    // Enumeration Info (can't change class name, though)
    // This is the main object that gets serialized for the Enumerate SOAP call
    [XmlRoot(Namespace = SoapConstants.EnumerationNamespace)]
    public class Enumerate
    {
        public Filter Filter { get; set; }

        [XmlElement(ElementName = "Selection", Namespace = SoapConstants.RmNamespace)]
        public string[] Selection { get; set; }

        [XmlElement(ElementName = "Sorting", Namespace = SoapConstants.RmNamespace)]
        public Sorting Sorting { get; set; }
    }

    public class Sorting
    {
        public Sorting()
        {
            Dialect = "http://schemas.microsoft.com/2006/11/XPathFilterDialect";
        }

        // TODO 003: Integration Test for Environment Variables
        // TODO 002: Use EndpointIdentity.CreateSpnIdentity("FIMService/" + addressFQDN)));
        // TODO 001: Change Environment Variables to have a base address instead of an enumeration endpoint
        // TODO 000: Implement sorting when we get a reply
        // TODO -001: Create Object
        //public Sorting(SortingAttribute attribute)
        //    : this()
        //{
        //    SortingAttribute = attribute;
        //}

        [XmlAttribute(AttributeName = "Dialect", DataType = "anyURI")]
        public string Dialect { get; set; }

        public SortingAttribute SortingAttribute { get; set; }
    }

    public class SortingAttribute
    {
        public SortingAttribute()
        {
            Ascending = true;
        }

        [XmlAttribute(AttributeName = "Ascending", DataType = "boolean")]
        public bool Ascending { get; set; }

        [XmlText]
        public string AttributeName { get; set; }
    }


}

using System.Xml.Serialization;

namespace IdmNet.SoapModels
{
    /// <summary>
    /// Yet another SOAP Model
    /// </summary>
    public class PullInfo
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public EnumerateResponse EnumerateResponse { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public EnumerationContext EnumerationContext
        {
            get { return EnumerateResponse.EnumerationContext; }
        }
    }


    /// <summary>
    /// Yet another SOAP Model
    /// </summary>
    [XmlRoot(Namespace = SoapConstants.EnumerateAction, IsNullable = false)]
    public class Filter
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public Filter()
        {
            Dialect = "http://schemas.microsoft.com/2006/11/XPathFilterDialect";
        }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public Filter(string query)
            : this()
        {
            Query = query;
        }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlAttribute(AttributeName = "Dialect", DataType = "anyURI")]
        public string Dialect { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlText]
        public string Query { get; set; }
    }



    /// <summary>
    /// Yet another SOAP Model
    /// </summary>
    public class PullAdjustment
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public PullAdjustment()
        {
            EnumerationDirection = "Forwards";
        }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public string EnumerationDirection { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public int StartingIndex { get; set; }
    }

    /// <summary>
    /// Yet another SOAP Model
    /// </summary>
    public class EnumerationContext
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlElement(Namespace = SoapConstants.RmNamespace)]
        public int CurrentIndex { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlElement(Namespace = SoapConstants.RmNamespace)]
        public string EnumerationDirection { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlElement(Namespace = SoapConstants.RmNamespace)]
        public string Expires { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlElement(Namespace = SoapConstants.RmNamespace)]
        public string Filter { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlArray(Namespace = SoapConstants.RmNamespace)]
        public string[] Selection { get; set; }
    }


    /// <summary>
    /// Yet another SOAP Model
    /// </summary>
    [XmlRoot(ElementName = "EnumerationDetail")]
    public class EnumerationCount
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlElement]
        public int Count { get; set; }
    }


    /// <summary>
    /// Yet another SOAP Model
    /// </summary>
    [XmlRoot(Namespace = SoapConstants.EnumerationNamespace)]
    public class EnumerateResponse
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public EnumerationContext EnumerationContext { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlElement(ElementName = "EnumerationDetail", Namespace = SoapConstants.RmNamespace)]
        public EnumerationCount EnumerationCount { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public string Expires { get; set; }
    }



    /// <summary>
    /// Yet another SOAP Model
    /// </summary>
    [XmlRoot(Namespace = SoapConstants.EnumerationNamespace)]
    public class Pull
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public EnumerationContext EnumerationContext { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public int MaxElements { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public PullAdjustment PullAdjustment { get; set; }
    }



    /// <summary>
    /// Yet another SOAP Model
    /// </summary>
    [XmlRoot(Namespace = SoapConstants.EnumerationNamespace)]
    public class PullResponse
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public object EndOfSequence { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public EnumerationContext EnumerationContext { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public object Items { get; set; }
    }


    /// <summary>
    /// Yet another SOAP Model
    /// Enumeration Info (can't change class name, though)
    /// This is the main object that gets serialized for the Enumerate SOAP call
    /// </summary>
    [XmlRoot(Namespace = SoapConstants.EnumerationNamespace)]
    public class Enumerate
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public Filter Filter { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlElement(ElementName = "Selection", Namespace = SoapConstants.RmNamespace)]
        public string[] Selection { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlElement(ElementName = "Sorting", Namespace = SoapConstants.RmNamespace)]
        public Sorting Sorting { get; set; }
    }

    /// <summary>
    /// Yet another SOAP Model
    /// </summary>
    public class Sorting
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public Sorting()
        {
            Dialect = "http://schemas.microsoft.com/2006/11/XPathFilterDialect";
        }

        // TODO -012: Implement Paging and redo sorting if we ever get a reply
        //public Sorting(SortingAttribute attribute)
        //    : this()
        //{
        //    SortingAttribute = attribute;
        //}

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlAttribute(AttributeName = "Dialect", DataType = "anyURI")]
        public string Dialect { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public SortingAttribute SortingAttribute { get; set; }
    }

    /// <summary>
    /// Yet another SOAP Model
    /// </summary>
    public class SortingAttribute
    {
        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        public SortingAttribute()
        {
            Ascending = true;
        }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlAttribute(AttributeName = "Ascending", DataType = "boolean")]
        public bool Ascending { get; set; }

        /// <summary>
        /// Part of a SOAP model
        /// </summary>
        [XmlText]
        public string AttributeName { get; set; }
    }
}
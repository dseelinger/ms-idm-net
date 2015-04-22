using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace IdmNet.SoapModels
{
    /// <summary>
    /// Defines information requried to do a "Pull" from a search in Identity Manager (WS-Enumerate)
    /// </summary>
    public class PullInfo
    {
        /// <summary>
        /// Information returned from the enumeration operations
        /// </summary>
        public EnumerateResponse EnumerateResponse { get; set; }

        /// <summary>
        /// number of objects to return in the pull
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// current "state" of the query - what object to start with (in case of paging, sorting, which fields to 
        /// populate, etc.)
        /// </summary>
        public EnumerationContext EnumerationContext
        {
            get { return EnumerateResponse.EnumerationContext; }
        }
    }


    /// <summary>
    /// Defines the XPath Filter/query for a search
    /// </summary>
    [XmlRoot(Namespace = SoapConstants.EnumerateAction, IsNullable = false)]
    public class Filter
    {
        /// <summary>
        /// Paremeterless CTOR
        /// </summary>
        public Filter()
        {
        }

        public Filter(string query)
        {
            Query = query;
        }

        /// <summary>
        /// Identity Manager XPath dialect - I suppose this was in case anything other than XPath was ever implemented 
        /// (but nothing ever has been)
        /// </summary>
        [XmlAttribute(AttributeName = "Dialect", DataType = "anyURI")]
        public string Dialect = "http://schemas.microsoft.com/2006/11/XPathFilterDialect";

        /// <summary>
        /// Actual XPath for the search
        /// </summary>
        [XmlText]
        public string Query { get; set; }
    }


    /// <summary>
    /// Additional information regarding the Pull
    /// </summary>
    public class PullAdjustment
    {
        /// <summary>
        /// CTOR - enumerate forwards by default
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
        /// Number of the next attribute to retrieve
        /// </summary>
        public int StartingIndex { get; set; }
    }

    /// <summary>
    /// Context for the next pull
    /// </summary>
    public class EnumerationContext
    {
        /// <summary>
        /// Current location in the search
        /// </summary>
        [XmlElement(Namespace = SoapConstants.RmNamespace)]
        public int CurrentIndex { get; set; }

        /// <summary>
        /// direction of enumeration
        /// </summary>
        [XmlElement(Namespace = SoapConstants.RmNamespace)]
        public string EnumerationDirection { get; set; }

        /// <summary>
        /// Always way in the future, so never really expires.  WS-Enumerate requirement
        /// </summary>
        [XmlElement(Namespace = SoapConstants.RmNamespace)]
        public string Expires { get; set; }

        /// <summary>
        /// XPATH Query
        /// </summary>
        [XmlElement(Namespace = SoapConstants.RmNamespace)]
        public string Filter { get; set; }

        /// <summary>
        /// Which attributes to populate
        /// </summary>
        [XmlArray(Namespace = SoapConstants.RmNamespace)]
        public string[] Selection { get; set; }

        /// <summary>
        /// How to sort results
        /// </summary>
        [XmlElement(ElementName = "Sorting", Namespace = SoapConstants.RmNamespace)]
        public Sorting Sorting { get; set; }
    }


    /// <summary>
    /// Contains count
    /// </summary>
    public class EnumerationDetail
    {
        /// <summary>
        /// Number of records returned in search
        /// </summary>
        [XmlElement]
        public int Count { get; set; }
    }


    /// <summary>
    /// Data returned from Enumeration
    /// </summary>
    [XmlRoot(Namespace = SoapConstants.EnumerationNamespace)]
    public class EnumerateResponse
    {
        /// <summary>
        /// Current context of the enumeration
        /// </summary>
        public EnumerationContext EnumerationContext { get; set; }

        /// <summary>
        /// Contains the count of records returned in the search
        /// </summary>
        [XmlElement(Namespace = SoapConstants.RmNamespace)]
        public EnumerationDetail EnumerationDetail { get; set; }

        /// <summary>
        /// Usually in the far future - WS-Enumerate requirement.
        /// </summary>
        public string Expires { get; set; }
    }



    /// <summary>
    /// Information for a Pull request
    /// </summary>
    [XmlRoot(Namespace = SoapConstants.EnumerationNamespace)]
    public class Pull
    {
        /// <summary>
        /// Context for the next PULL
        /// </summary>
        public EnumerationContext EnumerationContext { get; set; }

        /// <summary>
        /// Number of elements to retrieve
        /// </summary>
        public int MaxElements { get; set; }

        /// <summary>
        /// How to adjust the pull (paging, etc.)
        /// </summary>
        public PullAdjustment PullAdjustment { get; set; }
    }

    /// <summary>
    /// Response from the Pull operation
    /// </summary>
    [XmlRoot(Namespace = SoapConstants.EnumerationNamespace)]
    public class PullResponse
    {
        /// <summary>
        /// If no more items, TRUE
        /// </summary>
        public object EndOfSequence { get; set; }

        /// <summary>
        /// Context of the search after this last PULL
        /// </summary>
        public EnumerationContext EnumerationContext { get; set; }

        /// <summary>
        /// Objects/resources returned in the Pull
        /// </summary>
        public object Items { get; set; }
    }


    /// <summary>
    /// Enumeration Info (can't change class name, though)
    /// This is the main object that gets serialized for the Enumerate SOAP call
    /// </summary>
    //[XmlRoot(Namespace = SoapConstants.EnumerationNamespace)]
    [XmlRoot(ElementName = "Enumerate", IsNullable = false, Namespace = SoapConstants.EnumerationNamespace)]
    public class SearchCriteria
    {
        /// <summary>
        /// Default to selecting ObjectID and ObjectType and sorting by DisplayName
        /// </summary>
        public SearchCriteria(string filterQuery) : this()
        {
            Filter = new Filter(filterQuery);
        }

        /// <summary>
        /// Default to selecting ObjectID and ObjectType and sorting by DisplayName
        /// </summary>
        public SearchCriteria()
        {
            Selection = new List<string>  { "ObjectID", "ObjectType" };
            Sorting = new Sorting();
        }

        /// <summary>
        /// XPath Query
        /// </summary>
        public Filter Filter { get; set; }

        /// <summary>
        /// Which attributes to return
        /// </summary>
        [XmlElement(ElementName = "Selection", Namespace = SoapConstants.RmNamespace)]
        //public string[] Selection { get; set; }
        public List<string> Selection { get; set; }

        /// <summary>
        /// How to sort the results
        /// </summary>
        [XmlElement(ElementName = "Sorting", Namespace = SoapConstants.RmNamespace)]
        public Sorting Sorting { get; set; }
    }

    /// <summary>
    /// Sorting information for both Enumerate and Pull's Enumeration contexts
    /// </summary>
    [XmlRoot(IsNullable = true, Namespace = SoapConstants.RmNamespace)]
    public class Sorting
    {
        /// <summary>
        /// Default CTOR sorts by DisplayName, Ascending
        /// </summary>
        public Sorting()
        {
            SortingAttributes = new[] {new SortingAttribute()};
        }

        /// <summary>
        /// List of Attributes to sort by (and sort direction)
        /// </summary>
        [XmlElement(ElementName = "SortingAttribute")]
        public SortingAttribute[] SortingAttributes { get; set; }

        /// <summary>
        /// Always the RM namespace - WS-Enumerate requirment
        /// </summary>
        [XmlAttribute(AttributeName = "Dialect", DataType = "anyURI")] public string Dialect = SoapConstants.RmNamespace;
    }

    /// <summary>
    /// Information on how to sort fo a single attribute
    /// </summary>
    [XmlType(Namespace = SoapConstants.RmNamespace)]
    public class SortingAttribute
    {
        /// <summary>
        /// Default CTOR sorts by DisplayName, Ascending
        /// </summary>
        public SortingAttribute()
        {
            AttributeName = "DisplayName";
            Ascending = true;
        }
        
        /// <summary>
        /// Attribute's name
        /// </summary>
        [XmlText]
        public string AttributeName { get; set; }

        /// <summary>
        /// If true, sort ascending
        /// </summary>
        [XmlAttribute]
        public bool Ascending { get; set; }
    }
}
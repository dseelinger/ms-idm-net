namespace IdmNet
{
    public class SearchCriteria
    {
        public string XPath { get; set; }
        public string[] Attributes { get; set; }
        public string SortAttribute { get; set; }
        public bool SortDecending { get; set; }
        public int PageSize { get; set; }
    }
}

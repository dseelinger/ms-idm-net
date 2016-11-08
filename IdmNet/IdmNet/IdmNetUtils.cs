using System.Collections.Generic;
using System.Linq;

namespace IdmNet
{
    /// <summary>
    /// Contains utility methods for IdmNet
    /// </summary>
    public static class IdmNetUtils
    {
        /// <summary>
        /// Ensures that a list of selected attributes always contains the detault attributes of ObjectID and 
        /// ObjectType
        /// </summary>
        /// <param name="attributeList">List of additional attributes (if any) to add</param>
        /// <returns>A list that contains both the default and additional attributes</returns>
        public static List<string> EnsureDefaultSelectionPresent(List<string> attributeList)
        {
            List<string> finalList = new List<string> { "ObjectID", "ObjectType" };
            if (attributeList != null && attributeList.Count != 0)
            {
                finalList = finalList.Union(attributeList).ToList();
            }
            return finalList;
        }
    }
}

using System.Collections.Generic;

namespace IdmNet.Models
{
    public class KeywordedResource : IdmResource
    {
        public KeywordedResource()
        {
        }

        public KeywordedResource(IdmResource other)
        {
            Attributes = other.Attributes;
            if (other.Creator == null)
                return;
            Creator = other.Creator;
        }

        /// <summary>
        /// Resource Name
        /// </summary>
        public string Name
        {
            get { return GetAttrValue("Name"); }
            set { SetAttrValue("Name", value); }
        }

        /// <summary>
        /// List of alternate email addresses for the person (used by AD/Exchange)
        /// </summary>
        public List<string> UsageKeyword
        {
            get { return GetAttrValues("UsageKeyword"); }
            set { SetAttrValues("UsageKeyword", value); }
        }

        public virtual void CloneFrom(IdmResource other)
        {
            Attributes = other.Attributes;
            if (other.Creator == null)
                return;
            Creator = other.Creator;
        }
    }
}

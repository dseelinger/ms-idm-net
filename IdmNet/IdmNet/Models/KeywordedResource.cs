using System.Collections.Generic;

namespace IdmNet.Models
{
    /// <summary>
    /// Instatiate just for tests - holds attributes common among several classes: Name and UsageKeyword
    /// </summary>
    public class KeywordedResource : IdmResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public KeywordedResource()
        {
        }

        /// <summary>
        /// Base CTOR
        /// </summary>
        /// <param name="baseClass">Base class</param>
        public KeywordedResource(IdmResource baseClass)
        {
            Attributes = baseClass.Attributes;
            if (baseClass.Creator == null)
                return;
            Creator = baseClass.Creator;
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

        /// <summary>
        /// Clone attributes from another object into this one.
        /// </summary>
        /// <param name="other">Other resource</param>
        public virtual void CloneFrom(IdmResource other)
        {
            Attributes = other.Attributes;
            if (other.Creator == null)
                return;
            Creator = other.Creator;
        }
    }
}

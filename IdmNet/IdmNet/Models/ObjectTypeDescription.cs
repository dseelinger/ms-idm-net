using System.Collections.Generic;

namespace IdmNet.Models
{
    /// <summary>
    /// Resource Type Description - This describes a resource type.
    /// </summary>
    public class ObjectTypeDescription : KeywordedResource
    {
        /// <summary>
        /// Parameterless CTOR
        /// </summary>
        public ObjectTypeDescription()
        {
            
        }

        /// <summary>
        /// Build from an IdmResource
        /// </summary>
        /// <param name="resource"></param>
        public ObjectTypeDescription(IdmResource resource) : base(resource)
        {
        }

        /// <summary>
        /// List of associated BindingDescriptions 
        /// </summary>
        public List<BindingDescription> BindingDescriptions { get; set; }
    }
}

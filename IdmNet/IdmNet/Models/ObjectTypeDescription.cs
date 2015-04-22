using System.Collections.Generic;

namespace IdmNet.Models
{
    /// <summary>
    /// Resource Type Description - This describes a resource type.
    /// </summary>
    public class ObjectTypeDescription : KeywordedResource
    {
        public ObjectTypeDescription()
        {
            
        }

        public ObjectTypeDescription(IdmResource resource) : base(resource)
        {
        }

        public List<BindingDescription> BindingDescriptions { get; set; }
    }
}

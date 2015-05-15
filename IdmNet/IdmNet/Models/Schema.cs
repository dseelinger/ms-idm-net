using System.Collections.Generic;

namespace IdmNet.Models
{
    /// <summary>
    /// An object type description with Binding information associated with it.
    /// </summary>
    public class Schema : ObjectTypeDescription
    {
        /// <summary>
        /// Parameterless Constructor
        /// </summary>
        public Schema()
        {
            BindingDescriptions = new List<BindingDescription>();
        }

        /// <summary>
        /// Parameterized
        /// </summary>
        public Schema(IdmResource resource) : base(resource)
        {
            BindingDescriptions = new List<BindingDescription>();
        }

        /// <summary>
        /// List of associated BindingDescriptions 
        /// </summary>
        public List<BindingDescription> BindingDescriptions { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IdmNet
{
    /// <summary>
    /// Represents an individual Identity Manager resource's attribute and value
    /// </summary>
    [DataContract]
    public class IdmAttribute
    {
        /// <summary>
        /// Attribute name
        /// </summary>
        [Required]
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// List ov values for this attribute
        /// </summary>
        [DataMember]
        [Required]
        public List<string> Values { get; set; }

        /// <summary>
        /// Makes the native multi-valued nature of the Attribute look like a single-valued attribute
        /// </summary>
        public string Value
        {
            get
            {
                return Values.Count > 0 ? Values[0] : null;
            }
            set
            {
                Values.Clear();
                Values.Add(value);
            }
        }

        /// <summary>
        /// Parameterless Constructor
        /// </summary>
        public IdmAttribute()
        {
            Values = new List<string>();
        }
    }
}

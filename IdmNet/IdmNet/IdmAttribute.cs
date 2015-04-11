using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IdmNet
{
    [DataContract]
    public class IdmAttribute
    {
        [Required]
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public List<string> Values { get; set; }

        public string Value
        {
            get
            {
                if (Values.Count > 0)
                    return Values[0];
                return null;
            }
            set
            {
                Values.Clear();
                Values.Add(value);
            }
        }

        public IdmAttribute()
        {
            Values = new List<string>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        ///// <summary>
        ///// Convert the Value (string) of an attribute to DateTime, if the attribute is defined as a DateTime object
        ///// in Identity Manager
        ///// </summary>
        ///// <param name="attrName">Name of the attribute to retrieve</param>
        ///// <returns>Single (or first) DateTime value of the named attribute or null if the attribute is "not present"
        ///// in the Identity Manager resource</returns>
        //public DateTime? AttributeToDateTime(string attrName)
        //{
        //    DateTime? nullable = new DateTime?();
        //    string attrValue = GetAttrValue(attrName);
        //    if (attrValue != null)
        //        nullable = DateTime.Parse(attrValue);
        //    return nullable;
        //}


        /// <summary>
        /// Convert the Value (string) of an attribute to boolean, if the attribute is defined as a boolean
        /// in Identity Manager
        /// </summary>
        /// <returns>
        /// Boolean value of the attribute  or null if the attribute is "not present" in the Identity Manager 
        /// resource (and booleans may not be multi-valued attributes in Identity Manager)
        /// </returns>
        public bool? ToBool()
        {
            bool? nullable = new bool?();
            string attrValue = Value;
            if (attrValue != null)
                nullable = bool.Parse(attrValue);
            return nullable;
        }


        /// <summary>
        /// Convert the Value (string) of an attribute to DateTime, if the attribute is defined as a DateTime object
        /// in Identity Manager
        /// </summary>
        /// <returns>Single (or first) DateTime value of the attribute or null if the attribute is "not present"
        /// in the Identity Manager resource</returns>
        public DateTime? ToDateTime()
        {
            DateTime? nullable = new DateTime?();
            string attrValue = Value;
            if (attrValue != null)
                nullable = DateTime.Parse(attrValue);
            return nullable;
        }

        /// <summary>
        /// Convert the Values (strings) of an multi-valued attribute to DateTime, if the attribute is defined as a DateTime
        /// in Identity Manager
        /// </summary>
        /// <returns>List of DateTime values of the attribute or null if the attribute is "not present"
        /// in the Identity Manager resource</returns>
        public List<DateTime> ToDateTimes()
        {
            var times = new List<DateTime>();
            foreach (var value in Values)
            {
                var time = new DateTime();
                string attrValue = value;
                if (attrValue != null)
                    time = DateTime.Parse(attrValue);
                times.Add(time);
            }

            if (times.Count == 0)
                return null;
            return times;
        }

        /// <summary>
        /// Convert the Value (string) of an attribute to a binary value (byte[]), if the attribute is defined as 
        /// binary in Identity Manager
        /// </summary>
        /// <returns>Single (or first) binary value of the attribute or null if the attribute is "not present"
        /// in the Identity Manager resource</returns>
        public byte[] ToBinary()
        {
            byte[] result = null;
            string attrValue = Value;
            if (attrValue != null)
                result = Convert.FromBase64String(attrValue);
            return result;
        }


        /// <summary>
        /// Convert the Values (strings) of an multi-valued attribute to binary, if the attribute is defined as Binary
        /// in Identity Manager
        /// </summary>
        /// <returns>List of binary values of the attribute or null if the attribute is "not present"
        /// in the Identity Manager resource</returns>
        public List<byte[]> ToBinaries()
        {
            var results = Values.Select(Convert.FromBase64String).ToList();

            if (results.Count == 0)
                return null;
            return results;
        }

        /// <summary>
        /// Convert the Value (string) of an attribute to a integer value if the attribute is defined as such in
        /// Identity Manager
        /// </summary>
        /// <returns>
        /// Single (or first) integer value of the attribute or null if there are no values for the attribute
        /// </returns>
        public int? ToInteger()
        {
            int? nullable = new int?();
            string attrValue = Value;
            if (attrValue != null)
                nullable = int.Parse(attrValue);
            return nullable;
        }

        //public List<DateTime> ToDateTimes()
        //{
        //}

        public List<int> ToIntegers()
        {
            var integers = new List<int>();
            foreach (var value in Values)
            {
                var intValue = new int();
                string attrValue = value;
                if (attrValue != null)
                    intValue = int.Parse(attrValue);
                integers.Add(intValue);
            }

            if (integers.Count == 0)
                return null;
            return integers;
        }
    }
}

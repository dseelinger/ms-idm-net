using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
// ReSharper disable InconsistentNaming

namespace IdmNet
{
    /// <summary>
    /// Model to represents a basic resource in the Identity Manager Resource
    /// </summary>
    public class IdmResource
    {
        private IdmResource _creator;
        private List<IdmResource> _detectedRulesList;
        private List<IdmResource> _expectedRulesList;

        /// <summary>
        /// List of attributes for which we have data for this particular object.  Note that due to performance 
        /// reasons, there may be other attributes and values in the identity manager service, but they may not have been
        /// retrieved yet. 
        /// </summary>
        public List<IdmAttribute> Attributes { get; set; }

        /// <summary>
        /// (aka Resource ID) The value of the attribute is a globally unique identifier (GUID) assigned by FIM to 
        /// each resource when it is created. Note that it is not required here since this class also represents 
        /// resources that may not have been created as well as existing resources.
        /// </summary>
        public string ObjectID
        {
            get { return GetAttrValue("ObjectID"); }
            set { SetAttrValue("ObjectID", value); }
        }

        /// <summary>
        /// (aka Resource Type) The resource type of a resource. This attribute is assigned its value when the 
        /// resource is created in the FIM service database by the FIM service. It cannot be modified by any user.
        /// </summary>
        [Required]
        public virtual string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set { SetAttrValue("ObjectType", value); }
        }

        /// <summary>
        /// (aka Created Time) The time when the resource is created in the FIM service database. This attribute is 
        /// assigned its value by the FIM service. It cannot be modified by any user.
        /// </summary>
        public DateTime? CreatedTime
        {
            get { return GetAttr("CreatedTime") != null ? GetAttr("CreatedTime").ToDateTime() : null; }
            set { SetAttrValue("CreatedTime", value.ToString()); }
        }

        /// <summary>
        /// This is a reference attribute that refers to the resource that directly created the resource in the FIM 
        /// service database. This attribute is assigned its value by the FIM service. It cannot be modified by any 
        /// user.
        /// </summary>
        public IdmResource Creator
        {
            get { return GetAttributeAsComplexObject("Creator", _creator); }
            set
            {
                _creator = value;
                SetAttrValue("Creator", value.ObjectID);
            }
        }

        /// <summary>
        /// (aka Deleted Time) The time when the current resource is deleted from the FIM service database. This 
        /// attribute is assigned its value by the FIM service. It cannot be modified by any user.
        /// </summary>
        public DateTime? DeletedTime
        {
            get { return GetAttr("DeletedTime") != null ? GetAttr("DeletedTime").ToDateTime() : null; }
            set { SetAttrValue("DeletedTime", value.ToString()); }
        }

        /// <summary>
        /// Resource Description
        /// </summary>
        public string Description
        {
            get { return GetAttrValue("Description"); }
            set { SetAttrValue("Description", value); }
        }

        /// <summary>
        /// (aka Detected Rules List) The synchronization rules detected for resources in external systems.
        /// </summary>
        public List<IdmResource> DetectedRulesList
        {
            get { return GetMultiValuedAttrAsComplexObjects("DetectedRulesList", _detectedRulesList); }
            set { SetMultiValuedAttrAsComplexObjects("DetectedRulesList", out _detectedRulesList, value); }
        }



        /// <summary>
        /// (aka Display Name) Display name for the resource.
        /// </summary>
        public string DisplayName
        {
            get { return GetAttrValue("DisplayName"); }
            set { SetAttrValue("DisplayName", value); }
        }

        /// <summary>
        /// (aka Expected Rules List) This resource has been added to these Synchronization Rules and will be 
        /// manifested in external systems according to the Synchronization Rule definitions.
        /// </summary>
        public List<IdmResource> ExpectedRulesList
        {
            get { return GetMultiValuedAttrAsComplexObjects("ExpectedRulesList", _expectedRulesList); }
            set { SetMultiValuedAttrAsComplexObjects("ExpectedRulesList", out _expectedRulesList, value); }
        }

        /// <summary>
        /// (aka Expiration Time) The date and time when the resource expires. The appropriate Management Policy Rule 
        /// will delete the resource when the current date and time is later than the date and time specified in this 
        /// attribute.
        /// </summary>
        public DateTime? ExpirationTime
        {
            get { return GetAttr("ExpirationTime") != null ? GetAttr("ExpirationTime").ToDateTime() : null; }
            set { SetAttrValue("ExpirationTime", value.ToString()); }
        }

        /// <summary>
        /// The region and language for which the representation of a resource has been adapted.
        /// </summary>
        public string Locale
        {
            get { return GetAttrValue("Locale"); }
            set { SetAttrValue("Locale", value); }
        }

        /// <summary>
        /// (aka MV Resource ID) The GUID of an entry in the FIM metaverse corresponding to this resource.
        /// </summary>
        public string MVObjectID
        {
            get { return GetAttrValue("MVObjectID"); }
            set { SetAttrValue("MVObjectID", value); }
        }

        /// <summary>
        /// (aka Resource Time) The date and time of a representation of a resource. This attribute is updated by the 
        /// FIM service. This attribute can be used to define time triggered Management Policy Rules.
        /// </summary>
        public DateTime? ResourceTime
        {
            get { return GetAttr("ResourceTime") != null ? GetAttr("ResourceTime").ToDateTime() : null; }
            set { SetAttrValue("ResourceTime", value.ToString()); }
        }

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public IdmResource()
        {
            Attributes = new List<IdmAttribute>();
        }

        /// <summary>
        /// Get a particular attribute and its values by name
        /// </summary>
        /// <param name="attrName">Name of the attribute to retrieve from memory</param>
        /// <returns></returns>
        public IdmAttribute GetAttr(string attrName)
        {
            return Attributes.Find(a => a.Name == attrName);
        }

        /// <summary>
        /// Get just a single value from an attribute object by name
        /// </summary>
        /// <param name="attrName">Name of the attribute to retrieve</param>
        /// <returns>Single (or first) value of the named attribute</returns>
        public string GetAttrValue(string attrName)
        {
            if (GetAttr(attrName) != null)
                return GetAttr(attrName).Value;
            return null;
        }

        /// <summary>
        /// Get all attribute values from an attribute object by name
        /// </summary>
        /// <param name="attrName">Name of the attribute to retrieve</param>
        /// <returns>list of attrbute values</returns>
        public List<string> GetAttrValues(string attrName)
        {
            IdmAttribute attr = GetAttr(attrName);
            if (attr == null)
                return null;
            return attr.Values;
        }

        /// <summary>
        /// Set just a single value on a named attribute object
        /// </summary>
        /// <param name="attrName">Name of the attribute to set</param>
        /// <param name="value">Value to set for the attribute</param>
        public void SetAttrValue(string attrName, string value)
        {
            IdmAttribute attr = GetAttr(attrName);
            if (attr != null)
                attr.Value = value;
            Attributes.Add(new IdmAttribute()
            {
                Name = attrName,
                Value = value
            });
        }

        /// <summary>
        /// Set all attribute values on an named attribute object
        /// </summary>
        /// <param name="attrName">Name of the attribute to retrieve</param>
        /// <param name="values">list of attrbute values</param>
        public void SetAttrValues(string attrName, List<string> values)
        {
            IdmAttribute attr = GetAttr(attrName);
            if (attr != null)
                attr.Values = values;
            Attributes.Add(new IdmAttribute()
            {
                Name = attrName,
                Values = values
            });
        }

        /// <summary>
        /// Get the complex object that is backing a single-valued reference attribute in IdmNet.
        /// </summary>
        /// <typeparam name="T">Complex Object's type, such as "Person" for Creator</typeparam>
        /// <param name="attrName">Name of the single-valued attribute to retrieve</param>
        /// <param name="backingField">Object that contains the representation for the reference type</param>
        /// <returns>Strongly-typed single value for the Attribute</returns>
        public T GetAttributeAsComplexObject<T>(string attrName, T backingField) where T : IdmResource, new()
        {
            T obj = backingField;
            string attrValue = GetAttrValue(attrName);
            if (attrValue != null && (backingField == null || backingField.ObjectID != attrValue))
            {
                var instance = new T {ObjectID = attrValue};
                backingField = instance;
                obj = backingField;
            }
            return obj;
        }

        /// <summary>
        /// Get the list of complex objects that is backing a multi-valued reference attribute in IdmNet.
        /// </summary>
        /// <typeparam name="T">Complex Object's type, such as "Person" for a Group object's Owners</typeparam>
        /// <param name="attrName">Name of the multi-valued attribute to retrieve</param>
        /// <param name="backingField">List of objects that contains the available representations for the references</param>
        /// <returns>Strongly-typed list of values for the Attribute</returns>
        public List<T> GetMultiValuedAttrAsComplexObjects<T>(string attrName, List<T> backingField) where T : IdmResource, new()
        {
            List<T> list = backingField;
            List<string> attrValues = GetAttrValues(attrName);
            if (attrValues != null)
            {
                if (backingField == null)
                    backingField = new List<T>();
                backingField = attrValues.Select(objId => new
                {
                    objId,
                    existingMember = backingField.Find(r => r.ObjectID == objId)
                }).Select(param0 =>
                {
                    T existingMember = param0.existingMember;
                    if (existingMember != null)
                        return existingMember;
                    T instance = Activator.CreateInstance<T>();
                    instance.ObjectID = param0.objId;
                    return instance;
                }).ToList();
                list = backingField;
            }
            return list;
        }

        /// <summary>
        /// Set the list of complex objects that is backing a multi-valued reference attribute in IdmNet.
        /// </summary>
        /// <typeparam name="T">Complex Object's type, such as "Person" for a Group object's Owners</typeparam>
        /// <param name="attrName">Name of the multi-valued attribute to set</param>
        /// <param name="backingField">List of objects that will contain the representations for the references</param>
        /// <param name="values">List of objects that contains the representations for the references</param>
        public void SetMultiValuedAttrAsComplexObjects<T>(string attrName, out List<T> backingField, List<T> values)
            where T : IdmResource, new()
        {
            if (GetAttr(attrName) == null)
                Attributes.Add(new IdmAttribute()
                {
                    Name = attrName,
                    Values = new List<string>()
                });
            List<string> attrValues = GetAttrValues(attrName);
            attrValues.Clear();
            attrValues.AddRange(values.Select(r => r.ObjectID));
            backingField = values;
        }

        /// <summary>
        /// Resource Indexer - get's the attribute of the resource object as indexed by name.
        /// </summary>
        /// <param name="attributeName">Index by attribute name</param>
        public IdmAttribute this[string attributeName]
        {
            get { return GetAttr(attributeName); }
        }
    }
}

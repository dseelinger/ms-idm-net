using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace IdmNet
{
    public class IdmResource
    {
        private IdmResource _creator;

        public List<IdmAttribute> Attributes { get; set; }

        public string ObjectID
        {
            get { return GetAttrValue("ObjectID"); }
            set { SetAttrValue("ObjectID", value); }
        }

        [Required]
        public virtual string ObjectType
        {
            get { return GetAttrValue("ObjectType"); }
            set { SetAttrValue("ObjectType", value); }
        }

        public DateTime? CreatedTime
        {
            get { return AttributeToDateTime("CreatedTime"); }
            set { SetAttrValue("CreatedTime", value.ToString()); }
        }

        public IdmResource Creator
        {
            get { return GetAttributeAsComplexObject(_creator, "Creator"); }
            set
            {
                _creator = value;
                SetAttrValue("Creator", value.ObjectID);
            }
        }

        public DateTime? DeletedTime
        {
            get { return AttributeToDateTime("DeletedTime"); }
            set { SetAttrValue("DeletedTime", value.ToString()); }
        }

        public string Description
        {
            get { return GetAttrValue("Description"); }
            set { SetAttrValue("Description", value); }
        }

        public string DisplayName
        {
            get { return GetAttrValue("DisplayName"); }
            set { SetAttrValue("DisplayName", value); }
        }

        public DateTime? ExpirationTime
        {
            get { return AttributeToDateTime("ExpirationTime"); }
            set { SetAttrValue("ExpirationTime", value.ToString()); }
        }

        public string MVObjectID
        {
            get { return GetAttrValue("MVObjectID"); }
            set { SetAttrValue("MVObjectID", value); }
        }

        public DateTime? ResourceTime
        {
            get { return AttributeToDateTime("ResourceTime"); }
            set { SetAttrValue("ResourceTime", value.ToString()); }
        }

        public IdmResource()
        {
            Attributes = new List<IdmAttribute>();
        }

        public IdmAttribute GetAttr(string attrName)
        {
            return Attributes.Find(a => a.Name == attrName);
        }

        public string GetAttrValue(string attrName)
        {
            if (GetAttr(attrName) != null)
                return GetAttr(attrName).Value;
            return null;
        }

        public List<string> GetAttrValues(string attrName)
        {
            IdmAttribute attr = GetAttr(attrName);
            if (attr == null)
                return null;
            return attr.Values;
        }

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

        public DateTime? AttributeToDateTime(string attrName)
        {
            DateTime? nullable = new DateTime?();
            string attrValue = GetAttrValue(attrName);
            if (attrValue != null)
                nullable = DateTime.Parse(attrValue);
            return nullable;
        }

        public bool? AttributeToBool(string attrName)
        {
            bool? nullable = new bool?();
            string attrValue = GetAttrValue(attrName);
            if (attrValue != null)
                nullable = bool.Parse(attrValue);
            return nullable;
        }

        public T GetAttributeAsComplexObject<T>(T backingField, string attrName) where T : IdmResource, new()
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
    }
}

using System;
using System.ComponentModel;
using System.Reflection;

namespace RealEstateApp.HtmlHelpers
{
    public class LocalizedDisplayNameAttribute:DisplayNameAttribute
    {
        private PropertyInfo _nameProperty;
        private Type _resourceType;
        public string _displayName { get; set; }

        public LocalizedDisplayNameAttribute(string displayNameKey):base(displayNameKey)
        {
            _displayName = displayNameKey;
        }

        public Type NameResourceType
        {
            get { return _resourceType; }
            set
            {
                _resourceType = value;
                _nameProperty = _resourceType.GetProperty(_displayName, BindingFlags.Static | BindingFlags.NonPublic);
            }

        }

        public override string DisplayName
        {
            get
            {
                if (_nameProperty==null)
                {
                    return base.DisplayName;
                }
                return (string) _nameProperty.GetValue(_nameProperty.DeclaringType, null);
            }
        }
    }
}
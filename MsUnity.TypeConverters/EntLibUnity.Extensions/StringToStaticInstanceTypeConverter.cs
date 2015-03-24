using System;
using System.ComponentModel;
using System.Reflection;

namespace EntLibUnity.Extensions
{
    /// <summary>
    /// Converts an (formatted) string to a reference of a given static member.
    /// The string uses this format: {member}@{assemblyQualifiedName}
    /// For example:
    ///     Version@System.Environment, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
    /// </summary>
    public class StringToStaticInstanceTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return (typeof(string) == sourceType) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            string stringValue;
            if (value == null
                || (stringValue = value as string) == null
                || string.IsNullOrEmpty(stringValue)
                || !stringValue.Contains("@")
            )
            {
                return null;
            }

            var stringParts = stringValue.Split('@');
            if (stringParts.Length != 2)
            {
                return null;
            }
            var staticProperty = stringParts[0];
            var assemblyQualifiedName = stringParts[1];
            var staticClassType = Type.GetType(assemblyQualifiedName, true);
            var staticPropertyInfo = staticClassType.GetProperty(staticProperty,
                                                                 BindingFlags.Public | BindingFlags.Static |
                                                                 BindingFlags.FlattenHierarchy);
            var staticValue = staticPropertyInfo.GetValue(null, null) ?? base.ConvertFrom(context, culture, value);
            return staticValue;
        }
    }
}
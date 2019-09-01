using DouCalendarService.Contracts.Events;
using DouCalendarService.Contracts.Types;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;

namespace DouCalendarService.Contracts.Attributes
{
    public static class AttributeHelper
    {
        public static string GetValue<T, TAttribute>(
            Expression<Func<T, string>> propertyExpression,
            Func<TAttribute, string> valueSelector)
            where TAttribute : Attribute
        {
            var expression = (MemberExpression)propertyExpression.Body;
            var propertyInfo = (PropertyInfo)expression.Member;
            var attr = propertyInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
            return attr != null ? valueSelector(attr) : string.Empty;
        }

        public static string GetXPathLocationValue(Expression<Func<ShortEvent, string>> propertyExpression)
        {
            //var expression = (MemberExpression)propertyExpression.Body;
            //var propertyInfo = (PropertyInfo)expression.Member;
            //var attr = propertyInfo.GetCustomAttributes(typeof(XPathLocationAttribute), true).FirstOrDefault() 
            //    as XPathLocationAttribute;
            //return attr != null ? attr.Location : string.Empty;

            return GetValue<ShortEvent, XPathLocationAttribute>(propertyExpression, x => x.Location);
        }

        public static string GetEnumMemberValue(object enumVal, Type enumType)
        {
            var propertyInfo = enumType.GetMember(enumVal.ToString());
            var attr = propertyInfo
                .FirstOrDefault()
                .GetCustomAttributes(typeof(EnumMemberAttribute), true)
                .FirstOrDefault() as EnumMemberAttribute;

            return attr != null ? attr.Value : string.Empty;
        }
    }
}

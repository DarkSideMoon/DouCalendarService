using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DouCalendarService.Model.Attributes
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

        public static string GetValue<T>(Expression<Func<T, string>> propertyExpression)
        {
            var expression = (MemberExpression)propertyExpression.Body;
            var propertyInfo = (PropertyInfo)expression.Member;
            var attr = propertyInfo.GetCustomAttributes(typeof(XPathLocationAttribute), true).FirstOrDefault() 
                as XPathLocationAttribute;
            return attr != null ? attr.Location : string.Empty;
        }
    }
}

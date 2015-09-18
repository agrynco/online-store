#region Usings
using System;
using System.Linq.Expressions;
using System.Reflection;
#endregion

namespace OS.Common
{
    public static class PropertyMapper<T>
    {
        public static PropertyInfo PropertyInfo<U>(Expression<Func<T, U>> expression)
        {
            var member = expression.Body as MemberExpression;
            if (member != null && member.Member is PropertyInfo)
                return (PropertyInfo) member.Member;

            throw new ArgumentException("Expression is not a Property", nameof(expression));
        }

        public static string PropertyName<U>(Expression<Func<T, U>> expression)
        {
            return PropertyInfo(expression).Name;
        }

        public static Type PropertyType<U>(Expression<Func<T, U>> expression)
        {
            return PropertyInfo(expression).PropertyType;
        }
    }
}
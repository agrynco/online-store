using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace OS.Web
{
    public static class ModelStateExtensions
    {
        public static void RemoveStateFor<TModel, TProperty>(this ModelStateDictionary modelState, TModel model,
            Expression<Func<TModel, TProperty>> expression)
        {
            var key = ExpressionHelper.GetExpressionText(expression);

            modelState.Remove(key);
        }
    }
}
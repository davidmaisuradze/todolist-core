using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace TodoList.Api.Core.Attributes
{
    public class ModelValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                throw new Exception("validation error");
            }
        }
    }
}

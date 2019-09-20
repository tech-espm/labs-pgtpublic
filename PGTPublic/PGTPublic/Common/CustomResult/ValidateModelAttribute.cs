using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PGTPublic.Common.CustomResult
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ModelValidationResult(context.ModelState);
            }
        }
    }
}

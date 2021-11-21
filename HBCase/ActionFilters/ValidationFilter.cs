using HBCase.Model.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace HBCase.ActionFilters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState.Where(p => p.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.Select(y => y.ErrorMessage)).ToArray();

                var errorResponse = new BaseResponseResult();

                foreach (var error in errorsInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        errorResponse.Errors.Add($"FieldName: {error.Key} , Message: {subError}");
                    }
                }

                context.Result = new BadRequestObjectResult(errorResponse);
            }
        }
    }
}
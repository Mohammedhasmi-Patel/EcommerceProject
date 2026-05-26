using MegaEcommerce.Application.DTO.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MegaEcommerce.API.Filters
{
    public class ValidationModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var firstError = context.ModelState.SelectMany(x => x.Value?.Errors)
                                                    .FirstOrDefault()?.ErrorMessage ?? "Invalid Request Data";
                var response = ApiResponse<object>.ErrorResponse(firstError,400);
                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}

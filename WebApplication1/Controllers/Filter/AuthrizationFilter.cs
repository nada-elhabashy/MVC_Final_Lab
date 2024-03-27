using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers.Filter
{
    public class AuthrizationFilter : ActionFilterAttribute
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {

                context.Result = new RedirectToActionResult("AccessError", "Login", null);


            }
        }
    }
}

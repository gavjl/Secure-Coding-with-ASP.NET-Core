using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class EnforceStepUpAttribute : Attribute, IAuthorizationFilter
{
    public const string StepUpAllowPathName = "StepUpAllowPath";
    
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        string? email = context.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
        string? stepUpAllowPath = context.HttpContext.Session.GetString(email + StepUpAllowPathName)?.ToLower();
        if (!String.IsNullOrEmpty(stepUpAllowPath))
        {
            context.HttpContext.Session.Remove(email + StepUpAllowPathName);
            
            if (context.HttpContext.Request.Path.ToString().ToLower().Equals(stepUpAllowPath))
            {
                return;
            }

            context.HttpContext.Response.Redirect("/Identity/Account/Check2fa?ReturnUrl=" + context.HttpContext.Request.Path);
        }
        else
        {
            context.HttpContext.Response.Redirect("/Identity/Account/Check2fa?ReturnUrl=" + context.HttpContext.Request.Path);
        }
    }
}
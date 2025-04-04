using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;

public class RoleAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly string[] allowedRoles;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public RoleAuthorizeAttribute(IHttpContextAccessor httpContextAccessor, params string[] roles)
    {
        _httpContextAccessor = httpContextAccessor;
        this.allowedRoles = roles;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var httpContext = _httpContextAccessor.HttpContext;

        if (httpContext.Session.GetString("UserRole") == null)
        {
            context.Result = new RedirectResult("~/Account/Login");
            return;
        }

        string userRole = httpContext.Session.GetString("UserRole");
        if (!Array.Exists(allowedRoles, role => role.Equals(userRole, StringComparison.OrdinalIgnoreCase)))
        {
            context.Result = new RedirectResult("~/Account/Login");
        }
    }
}

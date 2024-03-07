using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ConsaludApiRest.Helpers
{
	public class TokenAuthorizationFilter : Attribute, IAuthorizationFilter
	{
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Verificar si el token está presente en el encabezado de autorización
            var token = context.HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(token))
            {
                // Si no se proporciona un token, devolver un HTTP status 401
                context.Result = new UnauthorizedResult();
            }
        }
    }
}


using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AdminPanel.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value;
            
            // Allow access to login page and API endpoints
            if (path == "/Account/Login" || path.StartsWith("/api/") || path == "/")
            {
                await _next(context);
                return;
            }

            // Check if user is authenticated
            var authData = context.Session.GetString("authData");
            if (string.IsNullOrEmpty(authData))
            {
                context.Response.Redirect("/Account/Login");
                return;
            }

            try
            {
                await _next(context);

                // If the response is 404, redirect to NotFound page
                if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
                {
                    context.Response.Redirect("/Home/NotFound");
                }
            }
            catch
            {
                // If any exception occurs, redirect to NotFound page
                if (!context.Response.HasStarted)
                {
                    context.Response.Redirect("/Home/NotFound");
                }
            }
        }
    }
} 
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComoViajamos.Filter
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private static String _tokenKey = "access_token";
        private static String _token = "f998dded8d0f8aca812d8e5fdea0143aa190ec4014239bc7e9d3bde3cbd9e140";

        private Boolean CompareTokens(String token)
        {
            Boolean CompareResult = token.Length.Equals(_token.Length);
            int index = 0;
            char tokenChar = ' ';
            char givenTokenChar = ' ';

            for (index = 0; index < _token.Length; index++)
            {
                tokenChar = _token.ElementAt(index);

                if (token.Length > index)
                {
                    givenTokenChar = token.ElementAt(index);
                }

                if (CompareResult)
                {
                    CompareResult = tokenChar.Equals(givenTokenChar);
                }               
            }

            return CompareResult;
        }

        public AuthenticationMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Boolean isTheUserUnauthorized = false;

            if (context.Request.Headers.ContainsKey(_tokenKey))
            {
                String givenToken = context.Request.Headers[_tokenKey];

                if (this.CompareTokens(givenToken))
                {
                    isTheUserUnauthorized = true;
                    await _next.Invoke(context);
                }
            }
            
            if (!isTheUserUnauthorized)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }
        }
    }

    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseSecurityMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}

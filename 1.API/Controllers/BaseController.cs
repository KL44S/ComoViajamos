using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace ComoViajamos.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
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

        private void PutUnauthorizedResult(ActionExecutingContext ActionContext)
        {
            ActionContext.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            try
            {
                IHeaderDictionary Headers = actionContext.HttpContext.Request.Headers;
                StringValues Token;

                if (!Headers.TryGetValue(_tokenKey, out Token))
                {
                    this.PutUnauthorizedResult(actionContext);
                }
                else
                {
                    if (!this.CompareTokens(Token))
                    {
                        this.PutUnauthorizedResult(actionContext);
                    }
                }

            }
            catch (Exception)
            {
                this.PutUnauthorizedResult(actionContext);
            }

        }
    }
}
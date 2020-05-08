using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Calc.Command.Exceptions;

namespace Calc.Api.Middleware
{
    /// <summary>
    /// The CommonMiddleware create token exist.
    /// </summary>
    public class CommonMiddleware
    {
        /// <summary>
        /// Apparently create a token.
        /// </summary>
        public string token = "a1b2c3d4";

        private readonly RequestDelegate _next;

        /// <summary>
        /// The CommonMiddleware initializes the delegate.
        /// </summary>
        /// <param name="next"></param>
        public CommonMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Containes token or return StatusCode: 400, if token not valid.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Invoke(HttpContext context)
        {
            var headers = context.Request.Headers;
            if (!headers.Values.Contains(token))
            {
                context.Response.StatusCode = 400;
                return context.Response.WriteAsync("Invalid token! Please, try better.");
            }
            return _next(context);
        }
    }
}

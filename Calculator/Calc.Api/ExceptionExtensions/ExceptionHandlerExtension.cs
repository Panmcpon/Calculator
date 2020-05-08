using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Calc.Api.ExceptionExtensions
{
    /// <summary>
    /// The ExceptionsFilterAttribute filter Calculator.
    /// </summary>
    public static class ExceptionHandlerExtension
    {
        /// <summary>
        /// The OnException filter Calculator for exceptions.
        /// </summary>
        public static void UseExceptionHandling(this IApplicationBuilder builder)
        {
            string message = null;
            builder.UseExceptionHandler(errorBuilder =>
            {
                errorBuilder.Use(async (context, func) =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var error = contextFeature.Error;
                        message = error.Message;
                    }
                    await context.Response.WriteAsync(message);
                });
            });
        }
    }
}
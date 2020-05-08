using Calc.Api.Middleware;
using Calc.Command.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calc.Api.UnitTests.Middleware
{
    public class CommonMiddlewareTests
    {
        [Theory]
        [InlineData(200, "a1b2c3d4")]
        [InlineData(400, "abacd")]
        public async Task CalcTokenAsyncTests(int statusCode, string token)
        {
            var commonMiddleware = new CommonMiddleware(
                next: (innerHttpContext) =>
                {
                    innerHttpContext.Response.WriteAsync("Invalid token");
                    return Task.CompletedTask;
                }
            );
            DefaultHttpContext defaultHttpContext = new DefaultHttpContext();
            defaultHttpContext.Request.Headers.Add("token", token);
            await commonMiddleware.Invoke(defaultHttpContext);
            var result = defaultHttpContext.Response.StatusCode;
            Assert.Equal(statusCode, result);
        }
    }
}

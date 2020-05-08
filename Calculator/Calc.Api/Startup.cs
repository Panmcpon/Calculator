using System;
using System.IO;
using System.Reflection;
using System.Web.Mvc;
using Calc.Api.ExceptionExtensions;
using Calc.Api.Middleware;
using Calc.Api.Util;
using Calc.Command.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Calc.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=39894
        public static ICalcRepository icalcRepository;

        private const string _swagger_version = "v1";

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddRazorPages();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(_swagger_version, new OpenApiInfo { Title = "Calculator Api", Version = _swagger_version });
                c.IncludeXmlComments(GetXmlCommentsPath());
            });

            var container = new ServiceResolver(services).GetServiceProvider();
            icalcRepository = container.GetService<ICalcRepository>();
            return container;
        }

        // The get xml comments path.
        private string GetXmlCommentsPath()
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            return xmlPath;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware(typeof(CommonMiddleware));
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{_swagger_version}/swagger.json", "Calculator Api");
            });

            app.UseRouting();

            app.UseExceptionHandling();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Calc.Command;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;

namespace Calc.Api.Util
{
    /// <summary>
    /// The ServiceResolver helps to registration WindsorContainer.
    /// </summary>
    public class ServiceResolver
    {
        private static IWindsorContainer _container;

        private static IServiceProvider _serviceProvider;

        /// <summary>
        /// The constructor ServiceResolver registarted components for WindsorContainer.
        /// Add and configure Json.
        /// Configure logging.
        /// </summary>
        /// <param name="services"></param>
        public ServiceResolver(IServiceCollection services)
        {

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _container = new WindsorContainer().Install(new ContainerExtensions());
            _serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(_container, services);

            try
            {
                Log.Logger = new LoggerConfiguration()
                       .ReadFrom.Configuration(configuration)
                       .CreateLogger();
            }
            catch (Exception ex)
            {
                Log.Error($"Error: {ex}");
            }
        }

        /// <summary>
        /// The IServiceProvider ini obj ser provider uses interface.
        /// </summary>
        /// <returns></returns>
        public IServiceProvider GetServiceProvider()
        {
            return _serviceProvider;
        }
    }
}

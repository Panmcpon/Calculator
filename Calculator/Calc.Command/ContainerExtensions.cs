using Calc.Command.Repositories;
using Calc.Command.Services;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;

namespace Calc.Command
{
    /// <summary>
    /// IoC Container Extensions.
    /// </summary>
    public class ContainerExtensions : IWindsorInstaller
    {
        /// <summary>
        /// The Install registrations WindsoreContainer.
        /// </summary>
        /// <param name="container"></param>
        /// <param name="store"></param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }

            container.Register(Component.For<ICalcRepository>()
                .ImplementedBy<CalcService>()
                .LifestyleSingleton());
        }
    }
}
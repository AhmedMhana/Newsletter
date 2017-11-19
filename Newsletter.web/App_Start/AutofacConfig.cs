using Autofac;
using Autofac.Integration.Mvc;
using DatabaseLayer;
using Interfaces;
using Services;
using System.Reflection;

namespace Newsletter.web
{
    public class AutoFacConfig
    {
        public static IContainer BuildContainer()
        {
            //Implement AutoFac "Dependency Injection"
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<SubscriberService>().As<ISubscriberService>();

            return builder.Build();
        }
    }
}
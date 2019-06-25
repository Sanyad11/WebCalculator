using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;

namespace WebCalculator
{
    public class DependencyInjection
    {
        public void Application_Start()
        {
                var builder = new ContainerBuilder();
                builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
                var container = builder.Build();
                builder.Register(c => new Manager.Manager())
                   .As<Manager.IManager>()
                   .InstancePerApiControllerType(typeof(Controllers.ValuesController));
                builder.Register(c => new WorkWithDB.DapperConnector())
                   .As<WorkWithDB.IDBConnector>()
                   .SingleInstance();
        }
    }
}

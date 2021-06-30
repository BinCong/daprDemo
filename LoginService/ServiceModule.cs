
using System.Threading.Tasks;
using Autofac;
using Oxygen.Client.ServerSymbol.Events;
using aspnetcoreDemo.Core.Common;


namespace LoginService
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AssemblyHelper.GetProjectAssemblies()).Where(x => !AssemblyHelper.IsSystemType(x))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();


            AssemblyHelper.RegisterAllEventHandlerInAutofac(AssemblyHelper.GetProjectAssemblies(), builder);
        }
    }
}

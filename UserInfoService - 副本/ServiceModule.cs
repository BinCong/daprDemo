
using System.Threading.Tasks;
using Autofac;
using Oxygen.Client.ServerSymbol.Events;
using aspnetcoreDemo.Core.Common;
using aspnetcoreDemo.Core.Repository;


namespace UserInfoService
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As(typeof(IUnitOfWork)).InstancePerDependency();

            builder.RegisterAssemblyTypes(AssemblyHelper.GetProjectAssemblies()).Where(x => !AssemblyHelper.IsSystemType(x))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();


            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();

            AssemblyHelper.RegisterAllEventHandlerInAutofac(AssemblyHelper.GetProjectAssemblies(), builder);
        }
    }
}

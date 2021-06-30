
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System;
using Autofac;
using Microsoft.Extensions.DependencyModel;
using Oxygen.Client.ServerSymbol.Events;

namespace aspnetcoreDemo.Core.Common
{
    public class AssemblyHelper
    {
        static Lazy<Assembly[]> Assemblies = new Lazy<Assembly[]>(() =>
          {
              var result = new List<Assembly>();

              foreach (var lib in DependencyContext.Default.CompileLibraries.Where(lib => !lib.Serviceable
                   && lib.Type != "package" && lib.Type != "referenceassembly"))
              {
                  try
                  {
                      result.Add(AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(lib.Name)));
                  }
                  catch (Exception)
                  {
                  }
              }

              return result.ToArray();

          });



        public static Assembly[] GetProjectAssemblies()
        {
            return Assemblies.Value;
        }

        static string[] SystemAssemblyQualifiledName = new string[] { "Microsoft", "System" };

        public static bool IsSystemType(Type type, bool checkBaseType = true, bool checkInterfaces = true)
        {
            if (SystemAssemblyQualifiledName.Any(x => type.AssemblyQualifiedName.StartsWith(x))) return true;
            else
            {
                if (checkBaseType && type.BaseType != null && type.BaseType != typeof(object) &&
                    SystemAssemblyQualifiledName.Any(x => type.BaseType.AssemblyQualifiedName.StartsWith(x)))
                    return true;

                if (checkInterfaces && type.GetInterfaces().Any())
                {
                    if (type.GetInterfaces().Any(x => SystemAssemblyQualifiledName.Any(p => x.AssemblyQualifiedName.StartsWith(p))))
                        return true;
                }
            }

            return false;
        }


        public static void RegisterAllEventHandlerInAutofac(Assembly[] assemblies,ContainerBuilder builder)
        {
            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes().Where(x => !x.IsInterface && x.GetInterface(nameof(IEventHandler)) != null))
                {
                    builder.RegisterType(type).As(type).InstancePerLifetimeScope();
                }
            }
        }


    }


}


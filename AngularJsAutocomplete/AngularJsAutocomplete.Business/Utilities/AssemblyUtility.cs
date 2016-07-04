using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AngularJsAutocomplete.Business.Utilities
{
    public static class AssemblyUtility
    {
        private const string AssemblyFilter = "AngularJsAutocomplete";

        public static IEnumerable<string> RelatedAssemblies
        {
            get
            {
                return AppDomain.CurrentDomain.GetAssemblies()
                    .Where(assembly => assembly.FullName.StartsWith(AssemblyFilter, StringComparison.OrdinalIgnoreCase))
                    .Select(assembly => assembly.Location).ToArray();
            }
        }

        private static BasedOnDescriptor CreateAssemblyFilter()
        {
            return Classes.FromAssemblyInDirectory(new AssemblyFilter(HttpRuntime.BinDirectory, AssemblyFilter + ".*")).Pick();
        }

        public static BasedOnDescriptor GetControllerDescriptor()
        {
            return CreateAssemblyFilter()
                .If(type => type.Name.EndsWith("Controller"))
                .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                .LifestylePerWebRequest();
        }
    }
}

using AngularJsAutocomplete.Business.Services;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsAutocomplete.Business.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(
                Component.For<IEdmundApiService>()
                .ImplementedBy<EdmundApiService>()
                .LifestyleTransient());

            container.Register(
                Component.For<IJsonToPocoParserService>()
                .ImplementedBy<JsonToPocoParserService>().
                LifestyleTransient());

            container.Register(
                Component.For<IEdmundDbRepository>()
                .ImplementedBy<EdmundDbRepository>()
                .LifestyleTransient());
        }
    }
}

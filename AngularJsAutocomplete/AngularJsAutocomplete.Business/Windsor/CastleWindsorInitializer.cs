using AngularJsAutocomplete.Business.Installers;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsAutocomplete.Business.Windsor
{
    public class CastleWindsorInitializer
    {
        public static IWindsorContainer Initialize()
        {
            var container = new WindsorContainer();

            InitializeCastleWindsor(container);
            // Register Installers
            RegisterInstallers(container);

            return container;
        }

        public static void InitializeCastleWindsor(IWindsorContainer container)
        {
            var windsorControllerFactory = new CastleWindsorControllerFactory(container.Kernel);
            System.Web.Mvc.ControllerBuilder.Current.SetControllerFactory(windsorControllerFactory);
        }

        private static void RegisterInstallers(IWindsorContainer container)
        {
            container.Install(new ServiceInstaller(), new ControllerInstaller());
        }
    }
}

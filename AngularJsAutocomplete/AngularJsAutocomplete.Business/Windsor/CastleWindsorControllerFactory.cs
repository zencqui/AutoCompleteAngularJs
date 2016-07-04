using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AngularJsAutocomplete.Business.Windsor
{
    public class CastleWindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;

        public CastleWindsorControllerFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (Type.ReferenceEquals(controllerType, null))
            {
                return null;
            }

            if (this.kernel.HasComponent(controllerType))
            {
                return this.kernel.Resolve(controllerType) as IController;
            }

            return base.GetControllerInstance(requestContext, controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            this.kernel.ReleaseComponent(controller);
        }
    }
}

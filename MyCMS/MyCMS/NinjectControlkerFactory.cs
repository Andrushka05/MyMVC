using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MyCMS.Models.Abstract;
using MyCMS.Models.Concrete;
using Ninject;

namespace MyCMS
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;
        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext,
        Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)_ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            // put additional bindings here
            _ninjectKernel.Bind<IContactRepository>().To<EfContactRepository>();

        }
    }
}
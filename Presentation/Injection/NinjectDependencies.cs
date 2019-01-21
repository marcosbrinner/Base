using Infra.orm.IService;
using Infra.orm.Service;
using Ninject;
using Ninject.Web.Mvc;
using System.Web.Mvc;

namespace Presentation.Injection
{
    public class NinjectDependencies
    {
        public static void ConfigureDependencies()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<ITesteService>().To<TesteService>();
            kernel.Bind<ITesteService>().To<TesteService>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
        
    }
}
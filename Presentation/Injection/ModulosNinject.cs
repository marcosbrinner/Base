using Infra.orm.IService;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.Injection
{
    public class ModulosNinject : NinjectModule
    {
        public override void Load()
        {
            
            Bind<ITesteService>().To<ITesteService>();
        }
    }
}
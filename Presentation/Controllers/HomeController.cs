using Infra.orm.IService;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITesteService _testeService;
        public HomeController(ITesteService testeService)
        {
            _testeService = testeService;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            _testeService.createNew();
            return View();
        }
    }
}

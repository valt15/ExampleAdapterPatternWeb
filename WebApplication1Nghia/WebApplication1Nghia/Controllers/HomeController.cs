using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationAI.Models;

namespace WebApplication1Nghia.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string GetName(string name)
        {
            Model model = new Model();
            return model.GetName(name);
        }
    }
}
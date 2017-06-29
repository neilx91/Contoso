using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contoso.Filters;

namespace Contoso.Controllers
{
    [ContosoExceptionFilter]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            //throw new DivideByZeroException();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult ErrorHappened()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
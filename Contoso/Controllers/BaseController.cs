using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contoso.Infrastructure;

namespace Contoso.Controllers
{
    public class BaseController : Controller
    {
        // GET: BaseController
        public new virtual ContosoPrincipal User
        {
            get { return HttpContext.User as ContosoPrincipal; }
        }
    }
}
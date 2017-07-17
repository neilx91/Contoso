using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contoso.Infrastructure;

namespace Contoso.Controllers
{
    // Create a base controller for accessing your User data in your all controller. Inherit, your all controller
    // from this base controller to access user information from the UserContext
    public class BaseController : Controller
    {
        // GET: BaseController
        public new virtual ContosoPrincipal User
        {
            get { return HttpContext.User as ContosoPrincipal; }
        }

    }
}
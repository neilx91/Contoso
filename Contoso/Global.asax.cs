using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Contoso.Infrastructure;
using Contoso.ViewModels;
using Newtonsoft.Json;

namespace Contoso
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                if (authTicket != null)
                {
                    var serializeModel = JsonConvert.DeserializeObject<ContosoPrincipleModel>(authTicket.UserData);
                    var newUser = new ContosoPrincipal(authTicket.Name)
                    {
                        PersonId = serializeModel.PersonId,
                        FirstName = serializeModel.FirstName,
                        LastName = serializeModel.LastName,
                        Roles = serializeModel.Roles
                    };

                    HttpContext.Current.User = newUser;
                }
            }
        }
    }
}
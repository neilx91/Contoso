using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contoso.Infrastructure
{
    //Create a base class for all your views for accessing your User data in your all views as shown below:
    // Register this class with in the \Views\Web.config as base class for all your views 


    /*
     * Now you can access the authenticated user information on all your view in easy and simple way as
     *  shown below in Admin View:
       
          @{
             ViewBag.Title = "Index";
             Layout = "~/Views/Shared/_AdminLayout.cshtml";
            }
            <h4>Welcome : @User.FirstName</h4>
            <h1>Admin DashBoard</h1>

     * */

    public abstract class BaseViewPage : WebViewPage
    {
        public new virtual ContosoPrincipal User
        {
            get { return base.User as ContosoPrincipal; }
        }
    }

    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public new virtual ContosoPrincipal User
        {
            get { return base.User as ContosoPrincipal; }
        }
    }
}
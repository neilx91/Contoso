using System.Web;
using System.Web.Mvc;
using Contoso.Filters;

namespace Contoso
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ContosoExceptionFilter());
        }
    }
}

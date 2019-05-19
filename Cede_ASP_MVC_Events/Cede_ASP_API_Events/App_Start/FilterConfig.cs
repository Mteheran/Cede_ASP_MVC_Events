using System.Web;
using System.Web.Mvc;

namespace Cede_ASP_API_Events
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

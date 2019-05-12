using System.Web;
using System.Web.Mvc;

namespace Cede_ASP_MVC_Events_EntityFramework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

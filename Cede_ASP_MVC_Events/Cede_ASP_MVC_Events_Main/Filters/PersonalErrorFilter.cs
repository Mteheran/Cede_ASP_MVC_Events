using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cede_ASP_MVC_Events_Main.Filters
{
    public class PersonalErrorFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            StreamWriter sw = new StreamWriter(@"C:\log\Eventslog.log");

            sw.WriteLine(filterContext.Exception.Message);

            sw.Close();
        }
    }
}
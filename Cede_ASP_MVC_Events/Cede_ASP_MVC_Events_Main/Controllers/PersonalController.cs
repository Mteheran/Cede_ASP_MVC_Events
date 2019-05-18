using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cede_ASP_MVC_Events_Main.Controllers
{
    public class PersonalController : Controller
    {
        // GET: Personal
        public ActionResult Index()
        {
            List<wsPersonalService.PersonalDto> personalList = new wsPersonalService.PersonalServiceSoapClient().GetPersonal().ToList();

            return View(personalList);
        }
    }
}
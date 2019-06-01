using Cede_ASP_MVC_Events_Main.Services;
using Cede_ASP_MVC_Events_Main.Services.Interfaces;
using Cede_ASP_MVC_Events_Main.Services.WebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Cede_ASP_MVC_Events_Main.Controllers
{
    public class PersonalController : Controller
    {
        public IPersonalService personalService { get; set; }

        public PersonalController()
        {
            personalService = new WebPersonalService();
        }

        // GET: Personal
        public async Task<ActionResult> Index()
        {
            var personalList = await personalService.GetPersonals();

            return View(personalList);
        }
    }
}
using Cede_ASP_MVC_Events_Main.Models;
using Cede_ASP_MVC_Events_Main.Services.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Cede_ASP_MVC_Events_Main.Controllers
{
    public class PersonalController : Controller
    {
        public IPersonalService personalService { get; set; }

        public PersonalController(IPersonalService service)
        {
            personalService = service;
        }

        // GET: Personal
        public async Task<ActionResult> Index()
        {
            var personalList = await personalService.GetPersonals();

            return View(personalList);
        }

        public async Task<ActionResult> Edit(string Id)
        {
            var objPersonal = await personalService.GetPersonalbyId(Id);

            return View(objPersonal);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Personal personal)
        {
            if (this.ModelState.IsValid)
            {
                var result = await personalService.SavePersonal(personal);

                if (result)
                {
                    return RedirectToAction("Index");
                }                
            }

            return View(personal);
        }
    }
}
using Cede_ASP_MVC_Events_Main.Filters;
using Cede_ASP_MVC_Events_Main.Models;
using Cede_ASP_MVC_Events_Main.Services.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Cede_ASP_MVC_Events_Main.Controllers
{
    [HandleError]
    [PersonalErrorFilter]
    public class PersonalController : Controller
    {
        public IPersonalService personalService { get; set; }

        public PersonalController(IPersonalService service)
        {
            personalService = service;
        }

        // GET: Personal
        //[NonAction]  ninguna accion, no puede ser accedido      
        public async Task<ActionResult> Index()
        {
            var personalList = await personalService.GetPersonals();

            return View(personalList);
        }

        [ActionName("PersonalList")]
        public async Task<ActionResult> PersonalList()
        {
            throw new System.Exception();

            var personalList = await personalService.GetPersonals();

            return View("Index", personalList);
        }

        //[PersonalErrorFilter] solo action
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


        [HttpPost]
        public async Task<ActionResult> Delete(string Id)
        {
                var result = await personalService.DeletePersonal(Id);

                if (!result)
                {
                    this.ModelState.AddModelError("","No fue posible eliminar el registro");
                }

            return RedirectToAction("Index");
        }
    }
}
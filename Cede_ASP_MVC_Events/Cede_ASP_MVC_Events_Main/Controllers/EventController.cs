using Cede_ASP_MVC_Events_Main.Models;
using Cede_ASP_MVC_Events_Main.Services;
using Cede_ASP_MVC_Events_Main.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Cede_ASP_MVC_Events_Main.Controllers
{
    [HandleError]
    public class EventController : Controller
    {
        public IEventService eventService { get; set; }
        public IPersonalService personalService { get; set; }

        public EventController(IEventService service, IPersonalService personal)
        {
            eventService = service;
            personalService = personal;
        }

        // GET: Event
        public async Task<ActionResult> Index()
        {
            var eventList = await eventService.GetEvents();

            return View(eventList);
        }

        [ActionName("EventList")]
        public async Task<ActionResult> EventList()
        {
            throw new System.Exception();

            var personalList = await personalService.GetPersonals();

            return View("Index", personalList);
        }

        public async Task<ActionResult> Edit(string Id)
        {
            var objEvent = await eventService.GetEventById(Id);

            await GetPersonalList();

            return View(objEvent);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Event objevent)
        {
            if (this.ModelState.IsValid)
            {
                var result = await eventService.SaveEvent(objevent);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            await GetPersonalList();
            return View(objevent);
        }

        private async Task GetPersonalList()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in await personalService.GetPersonals())
            {
                listItems.Add(new SelectListItem()
                {
                    Value = item.PersonalId.ToString(),
                    Text = $"{item.Name} {item.LastName}"
                });
            }

            ViewData["PersonalList"] = listItems;
        }
    }
}

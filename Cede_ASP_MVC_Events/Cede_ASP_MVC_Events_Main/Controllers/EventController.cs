using Cede_ASP_MVC_Events_Main.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Cede_ASP_MVC_Events_Main.Controllers
{
    public class EventController : Controller
    {
        public EventService eventService { get; set; }

        public EventController()
        {
            eventService = new EventService();
        }

        // GET: Event
        public async Task<ActionResult> Index()
        {
            var eventList = await eventService.GetEvents();

            return View(eventList);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cede_ASP_MVC_Events_EntityFramework.EFModel;

namespace Cede_ASP_MVC_Events_EntityFramework.Controllers
{
    public class EventController : Controller
    {
        private cnxEventter db = new cnxEventter();

        // GET: Event
        public async Task<ActionResult> Index()
        {
            var eventobj = db.Event.Include(x => x.Personal);
            return View(await eventobj.ToListAsync());
        }

        // GET: Event/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = await db.Event.FindAsync(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            ViewBag.PersonalId = new SelectList(db.Personal, "PersonalId", "Name");
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EventId,PersonalId,Name,Description,EventDate,IsPrivate,DateCreated,Status,IsDeleted")] Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.EventId = Guid.NewGuid();
                db.Event.Add(@event);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PersonalId = new SelectList(db.Personal, "PersonalId", "Name", @event.PersonalId);
            return View(@event);
        }

        // GET: Event/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = await db.Event.FindAsync(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonalId = new SelectList(db.Personal, "PersonalId", "Name", @event.PersonalId);
            return View(@event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EventId,PersonalId,Name,Description,EventDate,IsPrivate,DateCreated,Status,IsDeleted")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PersonalId = new SelectList(db.Personal, "PersonalId", "Name", @event.PersonalId);
            return View(@event);
        }

        // GET: Event/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = await db.Event.FindAsync(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Event @event = await db.Event.FindAsync(id);
            db.Event.Remove(@event);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

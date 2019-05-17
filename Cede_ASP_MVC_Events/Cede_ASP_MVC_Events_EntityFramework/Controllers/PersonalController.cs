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
    public class PersonalController : Controller
    {
        private cnxEventter db = new cnxEventter();

        // GET: Personal
        public async Task<ActionResult> Index()
        {
            return View(await db.Personal.ToListAsync());
        }

        // GET: Personal/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = await db.Personal.FindAsync(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // GET: Personal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PersonalId,Name,LastName,Email,IsDeleted,Phone")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(personal.Name) && string.IsNullOrEmpty(personal.LastName))
                {
                    ModelState.AddModelError("", "El Nombre y el apellido son requeridos");
                    return View(personal);
                }

                personal.PersonalId = Guid.NewGuid();
                db.Personal.Add(personal);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(personal);
        }

        // GET: Personal/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = await db.Personal.FindAsync(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // POST: Personal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PersonalId,Name,LastName,Email,IsDeleted,Phone")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personal).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(personal);
        }

        // GET: Personal/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal personal = await db.Personal.FindAsync(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }

        // POST: Personal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Personal personal = await db.Personal.FindAsync(id);
            db.Personal.Remove(personal);
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

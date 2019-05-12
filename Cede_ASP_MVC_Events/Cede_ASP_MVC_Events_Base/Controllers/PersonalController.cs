using Cede_ASP_MVC_Events_Base.Data;
using Cede_ASP_MVC_Events_Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cede_ASP_MVC_Events_Base.Controllers
{
    public class PersonalController : Controller
    {
        // GET: Personal
        public ActionResult Index()
        {
            var personaldata = PersonalData.GetPersonals(); 
            return View(personaldata);
        }

        // GET: Personal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Personal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personal/Create
        [HttpPost]
        public ActionResult SavePersonal(Personal collection)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View("Create");
                }

                PersonalData.SavePersonal(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Create");
            }
        }

        // GET: Personal/Edit/5
        public ActionResult Edit(string id)
        {
            var personalEdit = PersonalData.GetPersonals().FirstOrDefault(x => x.PersonalId == Guid.Parse(id));
            return View(personalEdit);
        }

        // POST: Personal/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Personal collection)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return View();
                }

                PersonalData.UpdatePersonal(collection);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

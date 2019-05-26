using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Cede_ASP_API_Events_EF.Context;
using Cede_ASP_API_Events_EF.Entities;

namespace Cede_ASP_API_Events.Controllers
{
    public class PersonalController : ApiController
    {
        private EventterContext db = new EventterContext();

        // GET: api/Personal
        public List<Personal> GetPersonal()
        {
            return db.Personal.ToList();
        }

        // GET: api/Personal/GetPersonalLinq
        [HttpGet]
        [ActionName("GetPersonalLinq")]
        [Route("api/GetPersonalLinq")]
        public List<Personal> GetPersonalLinq()
        {
            var listPersonal = from p in db.Personal
                               where p.Name.Contains("r") &&
                                      p.LastName.Contains("a")
                               select p;

            var listPersonalExtension = db.Personal.Where(p => p.LastName.EndsWith("z"));

            //var listconcated = Enumerable.Concat(listPersonal, listPersonalExtension);
            var listconcated = listPersonal.Concat(listPersonalExtension);

            var listrepeted = Enumerable.Repeat<Personal>(new Personal() { PersonalId = Guid.NewGuid(), Name = "Persona Name", LastName = "Persona lastname" }, 10);

            var listexcept = listconcated.Except(listPersonalExtension);

            //ejecutar queries directos a la base de datos
            
            //traer todas las personas que el Email sea nulo 
            // que el nombre contega i y que el apellido termine en n o en z 

            return listexcept.ToList();
        }

        // GET: api/Personal/5
        [ResponseType(typeof(Personal))]
        public async Task<IHttpActionResult> GetPersonal(Guid id)
        {
            Personal personal = await db.Personal.FindAsync(id);
            if (personal == null)
            {
                return NotFound();
            }

            return Ok(personal);
        }

        // PUT: api/Personal/5
        [ResponseType(typeof(Personal))]
        public async Task<IHttpActionResult> PutPersonal(Guid id, Personal personal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personal.PersonalId)
            {
                return BadRequest();
            }

            db.Entry(personal).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(personal);
        }

        // POST: api/Personal
        [ResponseType(typeof(Personal))]
        public async Task<IHttpActionResult> PostPersonal(Personal personal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Personal.Add(personal);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonalExists(personal.PersonalId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = personal.PersonalId }, personal);
        }

        // DELETE: api/Personal/5
        [ResponseType(typeof(Personal))]
        public async Task<IHttpActionResult> DeletePersonal(Guid id)
        {
            Personal personal = await db.Personal.FindAsync(id);
            if (personal == null)
            {
                return NotFound();
            }

            db.Personal.Remove(personal);
            await db.SaveChangesAsync();

            return Ok(personal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonalExists(Guid id)
        {
            return db.Personal.Count(e => e.PersonalId == id) > 0;
        }
    }

    public class PersonalNameLastName
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
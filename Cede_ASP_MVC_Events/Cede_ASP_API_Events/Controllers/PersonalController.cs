using System;
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
        public IQueryable<Personal> GetPersonal()
        {
            return db.Personal;
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
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Cede_ASP_API_Events_EF.Context;
using Cede_ASP_API_Events_EF.Entities;

namespace Cede_ASP_API_Events.Controllers
{
    public class EventController : ApiController
    {
        private EventterContext db = new EventterContext();

        // GET: api/Event
        public IQueryable<Event> GetEvents()
        {
            return db.Events;
        }

        // GET: api/Event/5
        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> GetEvent(Guid id)
        {
            Event objevent = await db.Events.FindAsync(id);
            if (objevent == null)
            {
                return NotFound();
            }

            return Ok(objevent);
        }

        // PUT: api/Event/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEvent(Guid id, Event objevent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != objevent.EventId)
            {
                return BadRequest();
            }

            db.Entry(objevent).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Event
        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> PostEvent(Event objevent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Events.Add(objevent);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EventExists(objevent.EventId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = objevent.EventId }, objevent);
        }

        // DELETE: api/Event/5
        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> DeleteEvent(Guid id)
        {
            Event objevent = await db.Events.FindAsync(id);
            if (objevent == null)
            {
                return NotFound();
            }

            db.Events.Remove(objevent);
            await db.SaveChangesAsync();

            return Ok(objevent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventExists(Guid id)
        {
            return db.Events.Count(e => e.EventId == id) > 0;
        }
    }
}
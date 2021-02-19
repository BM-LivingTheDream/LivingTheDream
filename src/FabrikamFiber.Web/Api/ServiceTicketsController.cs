using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FabrikamFiber.DAL.Data;
using FabrikamFiber.DAL.Models;

namespace FabrikamFiber.Web.Api
{
    public class ServiceTicketsController : ApiController
    {
        private FabrikamFiberWebContext db = new FabrikamFiberWebContext();

        // GET: api/ServiceTickets
        public IQueryable<ServiceTicket> GetServiceTickets()
        {
            return db.ServiceTickets;
        }

        // GET: api/ServiceTickets/5
        [ResponseType(typeof(ServiceTicket))]
        public IHttpActionResult GetServiceTicket(int id)
        {
            ServiceTicket serviceTicket = db.ServiceTickets.Find(id);
            if (serviceTicket == null)
            {
                return NotFound();
            }

            return Ok(serviceTicket);
        }

        // PUT: api/ServiceTickets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiceTicket(int id, ServiceTicket serviceTicket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceTicket.ID)
            {
                return BadRequest();
            }

            db.Entry(serviceTicket).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTicketExists(id))
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

        // POST: api/ServiceTickets
        [ResponseType(typeof(ServiceTicket))]
        public IHttpActionResult PostServiceTicket(ServiceTicket serviceTicket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiceTickets.Add(serviceTicket);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = serviceTicket.ID }, serviceTicket);
        }

        // DELETE: api/ServiceTickets/5
        [ResponseType(typeof(ServiceTicket))]
        public IHttpActionResult DeleteServiceTicket(int id)
        {
            ServiceTicket serviceTicket = db.ServiceTickets.Find(id);
            if (serviceTicket == null)
            {
                return NotFound();
            }

            db.ServiceTickets.Remove(serviceTicket);
            db.SaveChanges();

            return Ok(serviceTicket);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceTicketExists(int id)
        {
            return db.ServiceTickets.Count(e => e.ID == id) > 0;
        }
    }
}
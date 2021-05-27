using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week4.EntityFrk.Core;
using Week4.EntityFrk.EF;

namespace Week4.Demo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private TicketContext ctx;

        public TicketController()
        {
            this.ctx = new TicketContext();
        }

        // GET https://hostname/Ticket
        [HttpGet]
        public ActionResult Get()
        {
            // MOCK
            //var result = new List<Ticket>
            //{
            //    new Ticket { Id = 1, Title = "Primo Ticket" },
            //    new Ticket { Id = 1, Title = "Secondo Ticket" },
            //};

            var result = this.ctx.Tickets.ToList();

            return Ok(result);
        }

        // GET https://hostname/ticket/13
        [HttpGet("{ticketId}")]
        public ActionResult GetById(int ticketId)
        {
            if (ticketId <= 0)
                return BadRequest("Invalid Ticket ID.");    // HTTP 400

            var ticket = this.ctx.Tickets.Find(ticketId);

            if (ticket == null)
                return NotFound($"Ticket with Id = {ticketId} is missing.");    // HTTP 404

            return Ok(ticket);  // HTTP 200

            // MOCK
            //return Ok(new Ticket
            //{
            //    Id = ticketId,
            //    Title = $"Ticket con id = {ticketId}"
            //});     // HTTP 200

        }

        // POST https://hostname/Ticket
        [HttpPost]
        // Model Binding (JSON in HTTP Request => Ticket instance)
        public ActionResult PostNewTicket(Ticket newTicket) //Action
        {
            if (newTicket == null)
                return BadRequest("Invalid Ticket data.");

            this.ctx.Tickets.Add(newTicket);
            this.ctx.SaveChanges();

            return Created($"/ticket/{newTicket.Id}", newTicket); // HTTP 201
        }

        // PUT https://hostname/Ticket/13
        [HttpPut("{id}")]
        // Model Binding
        public ActionResult PutTicket(int id, [FromBody] Ticket editedTicket)
        {
            if (editedTicket == null)
                return BadRequest("Invalid Ticket data.");

            if (id != editedTicket.Id)
                return BadRequest("Ticket IDs don't match.");

            ctx.Tickets.Update(editedTicket);
            ctx.SaveChanges();

            return Ok();    // HTTP 200
        }

        // DELETE https://hostname/Ticket/13
        [HttpDelete("{id}")]
        public ActionResult DeleteTicket(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Ticket ID.");    // HTTP 400

            var ticketToBeDeleted = ctx.Tickets.Find(id);

            if (ticketToBeDeleted != null)
                ctx.Tickets.Remove(ticketToBeDeleted);

            ctx.SaveChanges();

            return Ok();    // HTTP 200
        }
    }
}

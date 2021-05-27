using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week4.EntityFrk.Core;

namespace Week4.Demo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        // GET https://hostname/Ticket
        [HttpGet]
        public ActionResult Get()
        {
            var result = new List<Ticket>
            {
                new Ticket { Id = 1, Title = "Primo Ticket" },
                new Ticket { Id = 1, Title = "Secondo Ticket" },
            };

            return Ok(result);
        }

        // GET https://hostname/ticket/13
        [HttpGet("{ticketId}")]
        public ActionResult GetById(int ticketId)
        {
            if (ticketId <= 0)
                return BadRequest("Invalid Ticket ID.");    // HTTP 400

            if (ticketId == 42)
                return NotFound($"Ticket with Id = {ticketId} is missing.");    // HTTP 404

            return Ok(new Ticket
            {
                Id = ticketId,
                Title = $"Ticket con id = {ticketId}"
            });     // HTTP 200
        }

        // POST https://hostname/Ticket
        [HttpPost]
        // Model Binding (JSON in HTTP Request => Ticket instance)
        public ActionResult PostNewTicket(Ticket newTicket) //Action
        {
            if (newTicket == null)
                return BadRequest("Invalid Ticket data.");

            return Created("", ""); // HTTP 201
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

            return Ok();    // HTTP 200
        }

        // DELETE https://hostname/Ticket/13
        [HttpDelete("{id}")]
        public ActionResult DeleteTicket(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Ticket ID.");    // HTTP 400

            return Ok();    // HTTP 200
        }
    }
}

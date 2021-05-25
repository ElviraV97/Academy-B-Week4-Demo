using System;
using System.Collections.Generic;
using Week4.EntityFrk.Core;
using Week4.EntityFrk.EF;

namespace Week4.EntityFrk.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Entity Framework - Week 4 ===");

            using TicketContext ctx = new();

            Ticket t = new()
            {
                Id = 1,
                Title = "Prima Prova",
                Description = "Prima Prova DESC",
                Category = new() { Id = 1, Name = "Development" }
            };

            ctx.Tickets.Add(t);
            ctx.SaveChanges();

            List<Ticket> tickets = new List<Ticket>();

            tickets.Add(t);
        }
    }
}

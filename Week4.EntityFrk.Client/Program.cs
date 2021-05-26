using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

            // READ + QUERY (LINQ)
            foreach (var item in ctx.Tickets.Include(t => t.Category))  // Eager Loading
                 Console.WriteLine($"[{item.Id}] {item.Title} ({item.Category.Name})");

            //var data = ctx.Tickets.Where(t => t.Id == 2);   // LINQ

            // ADD NEW ITEM - Persistenza del grafo
            //Ticket t = new()
            //{
            //    //Id = 1,
            //    Title = "Quarta Prova",
            //    Description = "Quarta Prova DESC",
            //    CategoryId = 1
            //    //Category = new() { 
            //    //    //Id = 1, 
            //    //    Name = "System" 
            //    //}
            //};

            //Ordine o = new()
            //{
            //    ID = 1,
            //    LineeOrdine = new List<Linee> { }
            //}

            //ctx.Tickets.Add(t);   // t state => ADDED

            // UPDATE

            //var t = ctx.Tickets.FirstOrDefault(t => t.Id == 3); // estraggo t (tracciato da ctx)

            //t.Title = "Titolo modificato";  // t state => MODIFIED

            //ctx.Tickets.Remove(t);  // t state => DELETED

            //ctx.SaveChanges();

            //List<Ticket> tickets = new List<Ticket>();

            //tickets.Add(t);
        }
    }
}

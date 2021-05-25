using Microsoft.EntityFrameworkCore;
using System;
using Week4.EntityFrk.Core;

namespace Week4.EntityFrk.EF
{
    public class TicketContext : DbContext
    {
        #region ctors

        public TicketContext() : base() { }

        // to be used with ASP.NET Core ...
        public TicketContext(DbContextOptions<TicketContext> options)
            : base(options) { }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                // configurazione locale
                var connString = "Server=.;Database=TicketEF;User ID=ticketing_usr;Password=T1cketing21;MultipleActiveResultSets=True;";

                optionsBuilder.UseSqlServer(connString);
            }
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Ticket>(new TicketConfiguration());

            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}

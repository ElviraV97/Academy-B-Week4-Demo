using Microsoft.EntityFrameworkCore;
using Week4.Core.EF.Configuration;
using Week4.Core.Model;

namespace Week4.Core.EF
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public LibraryContext(): base()
        {

        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                string connectionString = "Server=.;Database=BibliotecaB;User ID=ticketing_usr;Password=T1cketing21;MultipleActiveResultSets=True;";
                options.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Book>(new BookConfiguration());
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week4.Core.Model;

namespace Week4.Core.EF.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasKey(b => b.ISBN);

            builder
                .Property(b => b.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(b => b.Summary)
                .HasMaxLength(1000)
                .IsRequired();

            builder
                .Property(b => b.Author)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
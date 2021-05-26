using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week4.Core.Model;

namespace Week4.Core.EF
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder
                .HasKey(l => l.Id);

            builder
                .Property(l => l.User)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(l => l.LoanDate)
                .IsRequired();

            builder
                .HasOne(l => l.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.BookISBN);
        }
    }
}
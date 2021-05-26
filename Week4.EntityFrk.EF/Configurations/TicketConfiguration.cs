using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week4.EntityFrk.Core;

namespace Week4.EntityFrk.EF
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();

            // [MinLength(10)] come constraint
            builder
                .HasCheckConstraint("CK_Ticket_Title", "LEN([Title]) >= 10");
        }
    }
}
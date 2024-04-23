using FlyNest.SharedKernel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlyNest.Infrastructure.Persistence.Configurations;

public class FaqConfiguration : IEntityTypeConfiguration<Faq>
{
    public void Configure(EntityTypeBuilder<Faq> builder)
    {
        builder.ToTable(nameof(Faq));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Category).HasMaxLength(100);
        builder.Property(x => x.Question).HasMaxLength(300);
        builder.Property(x => x.Answer).HasMaxLength(1000);
        builder.HasData(
            new Faq
            {
                Id = 1,
                Question = "What are the visa requirements for international travel?",
                Answer = "Visa requirements vary depending on the destination country. It is recommended to check with the embassy or consulate of the destination country for the latest visa requirements.",
                Category = "Travel Requirements",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            },
            new Faq
            {
                Id = 2,
                Question = "How can I cancel my booking?",
                Answer = "You can cancel your booking by logging into your account on our website and following the cancellation process. Please note that cancellation fees may apply depending on the terms and conditions of your booking.",
                Category = "Booking",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            },
            new Faq
            {
                Id = 3,
                Question = "What are the check-in and check-out times for hotels?",
                Answer = "Check-in and check-out times vary depending on the hotel. Typically, check-in time is in the afternoon, and check-out time is in the morning. You can find specific check-in and check-out times on your booking confirmation or by contacting the hotel directly.",
                Category = "Accommodation",
                CreatedBy = 1,
                CreatedDate = DateTimeOffset.Now,
            }
        );
    }
}

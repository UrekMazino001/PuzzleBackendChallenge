using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationProject.Entities;

namespace ReservationProject.EntitiesConfiguration
{
    public class EventTypeConfiguration : IEntityTypeConfiguration<EventType>
    {
        public void Configure(EntityTypeBuilder<EventType> builder)
        {
            builder.Property(e => e.Description)
                    .IsRequired();

            List<EventType> events = new()
            {
                new EventType{ Id = 1, Description = "Birthday"},
                new EventType{ Id = 2, Description = "Wedding"},
                new EventType{ Id = 3, Description = "Conference"},
                new EventType{ Id = 4, Description = "Training"},
            };

            builder.HasIndex(e => e.Description).IsUnique();
            builder.HasData(events);
        }
    }
}

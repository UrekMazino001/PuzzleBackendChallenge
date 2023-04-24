using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationProject.Entities;
using ReservationProject.Enums;

namespace ReservationProject.EntitiesConfiguration
{
    public class FurnitureReservationConfiguration : IEntityTypeConfiguration<FurnitureReservation>
    {
        public void Configure(EntityTypeBuilder<FurnitureReservation> builder)
        {
            builder.HasKey(x => new { x.FurnitureId, x.ReservationId });
            builder.Property(x => x.Quantity).IsRequired();

        }

    }
}

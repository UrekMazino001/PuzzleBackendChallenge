using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationProject.Entities;
using ReservationProject.Enums;

namespace ReservationProject.EntitiesConfiguration
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {

        public void Configure(EntityTypeBuilder<Reservation> builder)
        {

            builder.ToTable(r => r.HasCheckConstraint("chkReservationStatus", "status in ('A', 'D')"));

            builder.Property(r => r.Status).HasMaxLength(1);
            builder.Property(r => r.StartTime).IsRequired();
            builder.Property(r => r.EndTime).IsRequired();
          
           // builder.Property(r => r.Status)
           //.IsRequired()
           //.HasMaxLength(1)
           //.IsFixedLength()
           //.HasConversion(
           //    rs => (ReservationStatus)Enum.Parse(typeof(ReservationStatus), rs.ToString()),
           //    rs => rs.ToString()
           //);
        }
    }
}

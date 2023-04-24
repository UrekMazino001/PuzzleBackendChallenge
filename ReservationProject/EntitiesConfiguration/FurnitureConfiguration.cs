using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationProject.Entities;
using ReservationProject.Enums;

namespace ReservationProject.EntitiesConfiguration
{
    public class FurnitureConfiguration : IEntityTypeConfiguration<Furniture>
    {

        public void Configure(EntityTypeBuilder<Furniture> builder)
        {

            builder.ToTable(f => f.HasCheckConstraint("chkFurniturStatus", "status in ('A', 'R')"));

            builder.Property(f => f.Status).HasMaxLength(1);
            builder.Property(f => f.Name)
                    .IsRequired()
                    .HasMaxLength(200);

            //builder.Property(f => f.Status)
            //       .IsRequired()
            //       .HasMaxLength(1)
            //       .IsFixedLength()
            //       .HasConversion(
            //           fs => (FurnitureStatus)Enum.Parse(typeof(FurnitureStatus), fs.ToString()),
            //           fs => fs.ToString()
            //       );
        }
    }
}

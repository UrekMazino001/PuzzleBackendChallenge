using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationProject.Entities;
using ReservationProject.Enums;
using ReservationProject.EnumExtensions;

namespace ReservationProject.EntitiesConfiguration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable(t => t.HasCheckConstraint("chkClientStatus", "status in ('A', 'D', 'C')"));
            builder.ToTable(t => t.HasCheckConstraint("chkClientClientType", "ClientType in ('P', 'C')"));

            builder.Property(c => c.ClientType).HasMaxLength(1);
            builder.Property(c => c.Status).HasMaxLength(1);

            builder.Property(c => c.Address)
            .IsRequired()
            .HasMaxLength(500);

            builder.Property(c => c.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);

            builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(300);

            //builder.Property(c => c.ClientType)
            //.IsRequired()
            //.HasMaxLength(1)
            //.IsFixedLength()
            //.HasConversion(
            //    tc => (ClientType)Enum.Parse(typeof(ClientType), tc.ToString()),
            //    tc => tc.ToString()
            //);

            //builder.Property(c => c.Status)
            //   .IsRequired()
            //  .HasMaxLength(1)
            //  .IsFixedLength()
            //  .HasConversion(
            //  tc => (ClientStatus)Enum.Parse(typeof(ClientStatus), tc.ToString()),
            //  tc => tc.ToString()
            //);
        }
    }
}

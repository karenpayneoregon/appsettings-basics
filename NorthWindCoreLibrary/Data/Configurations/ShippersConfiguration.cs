using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindCoreLibrary.Models;

#nullable disable

namespace NorthWindCoreLibrary.Data.Configurations
{
    public class ShippersConfiguration : IEntityTypeConfiguration<Shippers>
    {
        public void Configure(EntityTypeBuilder<Shippers> entity)
        {
            entity.HasKey(e => e.ShipperId);

            entity.Property(e => e.ShipperId)
                .ValueGeneratedNever()
                .HasColumnName("ShipperID");

            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.Phone).HasMaxLength(24);
        }
    }
}

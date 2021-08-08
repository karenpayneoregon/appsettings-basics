using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindCoreLibrary.Models;

#nullable disable

namespace NorthWindCoreLibrary.Data.Configurations
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> entity)
        {
            entity.HasKey(e => e.RegionId)
                .IsClustered(false);

            entity.Property(e => e.RegionId)
                .ValueGeneratedNever()
                .HasColumnName("RegionID");

            entity.Property(e => e.RegionDescription)
                .IsRequired()
                .HasMaxLength(50)
                .IsFixedLength(true);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindCoreLibrary.Models;

#nullable disable

namespace NorthWindCoreLibrary.Data.Configurations
{
    public class CategoriesConfiguration : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> entity)
        {
            entity.HasKey(e => e.CategoryId);

            entity.Property(e => e.CategoryId)
                .HasColumnName("CategoryID")
                .HasComment("Primary key");

            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            entity.Property(e => e.Description).HasColumnType("ntext");

            entity.Property(e => e.Picture).HasColumnType("image");
        }
    }
}

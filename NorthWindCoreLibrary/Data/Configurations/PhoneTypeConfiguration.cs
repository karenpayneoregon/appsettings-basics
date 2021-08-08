using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindCoreLibrary.Models;

#nullable disable

namespace NorthWindCoreLibrary.Data.Configurations
{
    public class PhoneTypeConfiguration : IEntityTypeConfiguration<PhoneType>
    {
        public void Configure(EntityTypeBuilder<PhoneType> entity)
        {
            entity.HasKey(e => e.PhoneTypeIdenitfier);
        }
    }
}

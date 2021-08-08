using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindCoreLibrary.Models;

#nullable disable

namespace NorthWindCoreLibrary.Data.Configurations
{
    public class CountriesConfiguration : IEntityTypeConfiguration<Countries>
    {
        public void Configure(EntityTypeBuilder<Countries> entity)
        {
            entity.HasKey(e => e.CountryIdentifier);
        }
    }
}

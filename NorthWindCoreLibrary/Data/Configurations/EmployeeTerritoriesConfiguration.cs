using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindCoreLibrary.Models;

#nullable disable

namespace NorthWindCoreLibrary.Data.Configurations
{
    public class EmployeeTerritoriesConfiguration : IEntityTypeConfiguration<EmployeeTerritories>
    {
        public void Configure(EntityTypeBuilder<EmployeeTerritories> entity)
        {
            entity.HasKey(e => new { e.EmployeeId, e.TerritoryId })
                .IsClustered(false);

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

            entity.Property(e => e.TerritoryId)
                .HasMaxLength(20)
                .HasColumnName("TerritoryID");

            entity.HasOne(d => d.Employee)
                .WithMany(p => p.EmployeeTerritories)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeTerritories_Employees");
        }
    }
}

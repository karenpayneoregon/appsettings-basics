﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWindCoreLibrary.Models;

#nullable disable

namespace NorthWindCoreLibrary.Data.Configurations
{
    public class SuppliersConfiguration : IEntityTypeConfiguration<Suppliers>
    {
        public void Configure(EntityTypeBuilder<Suppliers> entity)
        {
            entity.HasKey(e => e.SupplierId);

            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            entity.Property(e => e.City).HasMaxLength(15);

            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.ContactName).HasMaxLength(30);

            entity.Property(e => e.ContactTitle).HasMaxLength(30);

            entity.Property(e => e.Fax).HasMaxLength(24);

            entity.Property(e => e.HomePage).HasColumnType("ntext");

            entity.Property(e => e.Phone).HasMaxLength(24);

            entity.Property(e => e.PostalCode).HasMaxLength(10);

            entity.Property(e => e.Region).HasMaxLength(15);

            entity.Property(e => e.Street).HasMaxLength(60);

            entity.HasOne(d => d.CountryIdentifierNavigation)
                .WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CountryIdentifier)
                .HasConstraintName("FK_Suppliers_Countries");
        }
    }
}

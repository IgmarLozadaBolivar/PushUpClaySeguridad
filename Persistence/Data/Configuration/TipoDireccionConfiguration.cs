using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class TipoDireccionConfiguration : IEntityTypeConfiguration<TipoDireccion>
{
    public void Configure(EntityTypeBuilder<TipoDireccion> builder)
    {
        builder.ToTable("TipoDireccion");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("Id");
        builder.Property(e => e.Descripcion)
            .HasMaxLength(100)
            .HasColumnName("Descripcion");
    }
}
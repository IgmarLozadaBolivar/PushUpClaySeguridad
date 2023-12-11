using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class DirPersonaConfiguration : IEntityTypeConfiguration<DirPersona>
{
    public void Configure(EntityTypeBuilder<DirPersona> builder)
    {
        builder.ToTable("DirPersona");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.HasIndex(e => e.IdPersona, "dirPersona_FK");

        builder.HasIndex(e => e.IdTipoDireccion, "dirPersona_FK_1");

        builder.Property(e => e.Id).HasColumnName("Id");
        builder.Property(e => e.Direccion)
            .HasMaxLength(100)
            .HasColumnName("Direccion");
        builder.Property(e => e.IdPersona).HasColumnName("IdPersona");
        builder.Property(e => e.IdTipoDireccion).HasColumnName("IdTipoDireccion");

        builder.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Dirpersonas)
            .HasForeignKey(d => d.IdPersona)
            .HasConstraintName("dirPersona_FK");

        builder.HasOne(d => d.IdTipoDireccionNavigation).WithMany(p => p.Dirpersonas)
            .HasForeignKey(d => d.IdTipoDireccion)
            .HasConstraintName("dirPersona_FK_1");
    }
}
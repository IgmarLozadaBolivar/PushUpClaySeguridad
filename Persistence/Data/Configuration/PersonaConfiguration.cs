using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("Persona");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.HasIndex(e => e.IdCiudad, "persona_FK");

        builder.HasIndex(e => e.IdTipoPersona, "persona_FK_1");

        builder.HasIndex(e => e.IdCategoria, "persona_FK_2");

        builder.HasIndex(e => e.IdPersona, "persona_un").IsUnique();

        builder.Property(e => e.Id).HasColumnName("Id");
        builder.Property(e => e.DateReg).HasColumnName("DateReg");
        builder.Property(e => e.IdCategoria).HasColumnName("IdCategoria");
        builder.Property(e => e.IdCiudad).HasColumnName("IdCiudad");
        builder.Property(e => e.IdPersona)
            .IsRequired()
            .HasMaxLength(7)
            .HasColumnName("IdPersona");
        builder.Property(e => e.IdTipoPersona).HasColumnName("IdTipoPersona");
        builder.Property(e => e.Nombre)
            .HasMaxLength(50)
            .HasColumnName("Nombre");

        builder.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Personas)
            .HasForeignKey(d => d.IdCategoria)
            .HasConstraintName("persona_FK_2");

        builder.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Personas)
            .HasForeignKey(d => d.IdCiudad)
            .HasConstraintName("persona_FK");

        builder.HasOne(d => d.IdTipoPersonaNavigation).WithMany(p => p.Personas)
            .HasForeignKey(d => d.IdTipoPersona)
            .HasConstraintName("persona_FK_1");
    }
}
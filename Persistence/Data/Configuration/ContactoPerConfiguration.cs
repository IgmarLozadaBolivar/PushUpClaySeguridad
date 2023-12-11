using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class ContactoPerConfiguration : IEntityTypeConfiguration<ContactoPer>
{
    public void Configure(EntityTypeBuilder<ContactoPer> builder)
    {
        builder.ToTable("ContactoPer");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.HasIndex(e => e.Descripcion, "contactoPer_un").IsUnique();

        builder.HasIndex(e => e.IdPersona, "contactoPer_FK");

        builder.HasIndex(e => e.IdTipoContacto, "contactoPer_FK_1");

        builder.Property(e => e.Id).HasColumnName("Id");
        builder.Property(e => e.Descripcion)
            .HasMaxLength(100)
            .HasColumnName("Descripcion");
        builder.Property(e => e.IdPersona).HasColumnName("IdPersona");
        builder.Property(e => e.IdTipoContacto).HasColumnName("IdTipoContacto");

        builder.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Contactopers)
            .HasForeignKey(d => d.IdPersona)
            .HasConstraintName("contactoPer_FK");

        builder.HasOne(d => d.IdTipoContactoNavigation).WithMany(p => p.Contactopers)
            .HasForeignKey(d => d.IdTipoContacto)
            .HasConstraintName("contactoPer_FK_1");
    }
}
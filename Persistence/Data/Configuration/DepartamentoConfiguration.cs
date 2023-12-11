using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("Departamento");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.HasIndex(e => e.IdPais, "departamento_FK");

        builder.Property(e => e.Id).HasColumnName("Id");
        builder.Property(e => e.IdPais).HasColumnName("IdPais");
        builder.Property(e => e.NombreDep)
            .HasMaxLength(50)
            .HasColumnName("NombreDep");

        builder.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Departamentos)
            .HasForeignKey(d => d.IdPais)
            .HasConstraintName("departamento_FK");
    }
}
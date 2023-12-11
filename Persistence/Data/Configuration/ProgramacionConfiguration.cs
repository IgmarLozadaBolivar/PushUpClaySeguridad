using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class ProgramacionConfiguration : IEntityTypeConfiguration<Programacion>
{
    public void Configure(EntityTypeBuilder<Programacion> builder)
    {
        builder.ToTable("Programacion");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.HasIndex(e => e.IdContrato, "programacion_FK");

        builder.HasIndex(e => e.IdTurno, "programacion_FK_1");

        builder.HasIndex(e => e.IdEmpleado, "programacion_FK_2");

        builder.Property(e => e.Id).HasColumnName("Id");
        builder.Property(e => e.IdContrato).HasColumnName("IdContrato");
        builder.Property(e => e.IdEmpleado).HasColumnName("IdEmpleado");
        builder.Property(e => e.IdTurno).HasColumnName("IdTurno");

        builder.HasOne(d => d.IdContratoNavigation).WithMany(p => p.Programacions)
            .HasForeignKey(d => d.IdContrato)
            .HasConstraintName("programacion_FK");

        builder.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Programacions)
            .HasForeignKey(d => d.IdEmpleado)
            .HasConstraintName("programacion_FK_2");

        builder.HasOne(d => d.IdTurnoNavigation).WithMany(p => p.Programacions)
            .HasForeignKey(d => d.IdTurno)
            .HasConstraintName("programacion_FK_1");
    }
}
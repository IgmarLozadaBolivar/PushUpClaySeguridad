using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
{
    public void Configure(EntityTypeBuilder<Contrato> builder)
    {
        builder.ToTable("Contrato");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.HasIndex(e => e.IdEstado, "contrato_FK");

        builder.HasIndex(e => e.IdCliente, "contrato_FK_1");

        builder.HasIndex(e => e.IdEmpleado, "contrato_FK_2");

        builder.Property(e => e.Id).HasColumnName("Id");
        builder.Property(e => e.FechaContrato).HasColumnName("FechaContrato");
        builder.Property(e => e.FechaFin).HasColumnName("FechaFin");
        builder.Property(e => e.IdCliente).HasColumnName("IdCliente");
        builder.Property(e => e.IdEmpleado).HasColumnName("IdEmpleado");
        builder.Property(e => e.IdEstado).HasColumnName("IdEstado");

        builder.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ContratoIdClienteNavigations)
            .HasForeignKey(d => d.IdCliente)
            .HasConstraintName("contrato_FK_1");

        builder.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.ContratoIdEmpleadoNavigations)
            .HasForeignKey(d => d.IdEmpleado)
            .HasConstraintName("contrato_FK_2");

        builder.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Contratos)
            .HasForeignKey(d => d.IdEstado)
            .HasConstraintName("contrato_FK");
    }
}
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class TurnoConfiguration : IEntityTypeConfiguration<Turno>
{
    public void Configure(EntityTypeBuilder<Turno> builder)
    {
        builder.ToTable("Turno");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("Id");
        builder.Property(e => e.HoraTurnoFin)
            .HasColumnType("time")
            .HasColumnName("HoraTurnoFin");
        builder.Property(e => e.HoraTurnoInicio)
            .HasColumnType("time")
            .HasColumnName("HoraTurnoInicio");
        builder.Property(e => e.NombreTurno)
            .HasMaxLength(50)
            .HasColumnName("NombreTurno");
    }
}
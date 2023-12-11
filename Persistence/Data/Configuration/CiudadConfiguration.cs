using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.ToTable("Ciudad");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.HasIndex(e => e.IdDep, "ciudad_FK");

        builder.Property(e => e.Id).HasColumnName("Id");

        builder.Property(e => e.IdDep).HasColumnName("IdDep");
        builder.Property(e => e.NombreCiu)
            .HasMaxLength(50)
            .HasColumnName("NombreCiu");

        builder.HasOne(d => d.IdDepNavigation).WithMany(p => p.Ciudads)
            .HasForeignKey(d => d.IdDep)
            .HasConstraintName("ciudad_FK");
    }
}
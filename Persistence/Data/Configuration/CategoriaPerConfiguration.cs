using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configuration;

public class CategoriaPerConfiguration : IEntityTypeConfiguration<CategoriaPer>
{
    public void Configure(EntityTypeBuilder<CategoriaPer> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("CategoriaPer");

        builder.Property(e => e.Id).HasColumnName("Id");
        builder.Property(e => e.NombreCat)
            .HasMaxLength(50)
            .HasColumnName("NombreCat");
    }
}
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Reflection;
namespace Persistence.Data;

public partial class DbAppContext : DbContext
{
    public DbAppContext()
    {
    }

    public DbAppContext(DbContextOptions<DbAppContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<UserRol> UserRols { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<CategoriaPer> Categoriapers { get; set; }
    public virtual DbSet<Ciudad> Ciudads { get; set; }
    public virtual DbSet<ContactoPer> Contactopers { get; set; }
    public virtual DbSet<Contrato> Contratos { get; set; }
    public virtual DbSet<Departamento> Departamentos { get; set; }
    public virtual DbSet<DirPersona> Dirpersonas { get; set; }
    public virtual DbSet<Estado> Estados { get; set; }
    public virtual DbSet<Pais> Paises { get; set; }
    public virtual DbSet<Persona> Personas { get; set; }
    public virtual DbSet<Programacion> Programacions { get; set; }
    public virtual DbSet<TipoContacto> Tipocontactos { get; set; }
    public virtual DbSet<TipoDireccion> Tipodireccions { get; set; }
    public virtual DbSet<TipoPersona> Tipopersonas { get; set; }
    public virtual DbSet<Turno> Turnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;user=root;password=1122809631;database=claysecurity", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

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

    public virtual DbSet<Categoriaper> Categoriapers { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Contactoper> Contactopers { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Dirpersona> Dirpersonas { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Programacion> Programacions { get; set; }

    public virtual DbSet<Tipocontacto> Tipocontactos { get; set; }

    public virtual DbSet<Tipodireccion> Tipodireccions { get; set; }

    public virtual DbSet<Tipopersona> Tipopersonas { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;user=root;password=1122809631;database=claysecurity", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Categoriaper>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categoriaper");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.NombreCat)
                .HasMaxLength(50)
                .HasColumnName("nombreCat");
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ciudad");

            entity.HasIndex(e => e.IdDep, "ciudad_FK");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdDep).HasColumnName("idDep");
            entity.Property(e => e.NombreCiu)
                .HasMaxLength(50)
                .HasColumnName("nombreCiu");

            entity.HasOne(d => d.IdDepNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.IdDep)
                .HasConstraintName("ciudad_FK");
        });

        modelBuilder.Entity<Contactoper>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contactoper");

            entity.HasIndex(e => e.Descripcion, "contactoPer_un").IsUnique();

            entity.HasIndex(e => e.IdPersona, "contactoper_FK");

            entity.HasIndex(e => e.IdTipoContacto, "contactoper_FK_1");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.IdTipoContacto).HasColumnName("idTipoContacto");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Contactopers)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("contactoper_FK");

            entity.HasOne(d => d.IdTipoContactoNavigation).WithMany(p => p.Contactopers)
                .HasForeignKey(d => d.IdTipoContacto)
                .HasConstraintName("contactoper_FK_1");
        });

        modelBuilder.Entity<Contrato>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contrato");

            entity.HasIndex(e => e.IdEstado, "contrato_FK");

            entity.HasIndex(e => e.IdCliente, "contrato_FK_1");

            entity.HasIndex(e => e.IdEmpleado, "contrato_FK_2");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FechaContrato).HasColumnName("fechaContrato");
            entity.Property(e => e.FechaFin).HasColumnName("fechaFin");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ContratoIdClienteNavigations)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("contrato_FK_1");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.ContratoIdEmpleadoNavigations)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("contrato_FK_2");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("contrato_FK");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("departamento");

            entity.HasIndex(e => e.IdPais, "departamento_FK");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdPais).HasColumnName("idPais");
            entity.Property(e => e.NombreDep)
                .HasMaxLength(50)
                .HasColumnName("nombreDep");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.IdPais)
                .HasConstraintName("departamento_FK");
        });

        modelBuilder.Entity<Dirpersona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("dirpersona");

            entity.HasIndex(e => e.IdPersona, "dirpersona_FK");

            entity.HasIndex(e => e.IdTipoDireccion, "dirpersona_FK_1");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("direccion");
            entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            entity.Property(e => e.IdTipoDireccion).HasColumnName("idTipoDireccion");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Dirpersonas)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("dirpersona_FK");

            entity.HasOne(d => d.IdTipoDireccionNavigation).WithMany(p => p.Dirpersonas)
                .HasForeignKey(d => d.IdTipoDireccion)
                .HasConstraintName("dirpersona_FK_1");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("estado");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pais");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.NombrePais)
                .HasMaxLength(50)
                .HasColumnName("nombrePais");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("persona");

            entity.HasIndex(e => e.IdCiudad, "persona_FK");

            entity.HasIndex(e => e.IdTipoPersona, "persona_FK_1");

            entity.HasIndex(e => e.IdCategoria, "persona_FK_2");

            entity.HasIndex(e => e.IdPersona, "persona_un").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DateReg).HasColumnName("dateReg");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.IdCiudad).HasColumnName("idCiudad");
            entity.Property(e => e.IdPersona)
                .IsRequired()
                .HasMaxLength(7)
                .HasColumnName("idPersona");
            entity.Property(e => e.IdTipoPersona).HasColumnName("idTipoPersona");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("persona_FK_2");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("persona_FK");

            entity.HasOne(d => d.IdTipoPersonaNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdTipoPersona)
                .HasConstraintName("persona_FK_1");
        });

        modelBuilder.Entity<Programacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("programacion");

            entity.HasIndex(e => e.IdContrato, "programacion_FK");

            entity.HasIndex(e => e.IdTurno, "programacion_FK_1");

            entity.HasIndex(e => e.IdEmpleado, "programacion_FK_2");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdContrato).HasColumnName("idContrato");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdTurno).HasColumnName("idTurno");

            entity.HasOne(d => d.IdContratoNavigation).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.IdContrato)
                .HasConstraintName("programacion_FK");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("programacion_FK_2");

            entity.HasOne(d => d.IdTurnoNavigation).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.IdTurno)
                .HasConstraintName("programacion_FK_1");
        });

        modelBuilder.Entity<Tipocontacto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipocontacto");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Tipodireccion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipodireccion");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Tipopersona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipopersona");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("turno");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.HoraTurnoFin)
                .HasColumnType("time")
                .HasColumnName("horaTurnoFin");
            entity.Property(e => e.HoraTurnoInicio)
                .HasColumnType("time")
                .HasColumnName("horaTurnoInicio");
            entity.Property(e => e.NombreTurno)
                .HasMaxLength(50)
                .HasColumnName("nombreTurno");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Aburrimiento.Models;

public partial class BaggdbContext : DbContext
{
    public BaggdbContext()
    {
    }

    public BaggdbContext(DbContextOptions<BaggdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Bicicleta> Bicicletas { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Jugadore> Jugadores { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost; database=BAGGDB; Trusted_Connection=SSPI; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.EstadoSalud)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Bicicleta>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Dueño)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MarcaBici)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cliente1)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Cliente");
            entity.Property(e => e.Equipo)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.EstadoEquipo)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Jugadore>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Activo)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Equipo)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Nombre)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proveedo__3214EC2717E82C63");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Empresa)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

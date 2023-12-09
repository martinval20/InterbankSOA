using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI.Models
{
    public partial class bdSOAContext : DbContext
    {
        public bdSOAContext()
        {
        }

        public bdSOAContext(DbContextOptions<bdSOAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cuentum> Cuenta { get; set; } = null!;
        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        public virtual DbSet<Lugare> Lugares { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<TipoCuentum> TipoCuenta { get; set; } = null!;
        public virtual DbSet<TipoTransaccion> TipoTransaccions { get; set; } = null!;
        public virtual DbSet<Transaccion> Transaccions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bdSOA");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cuentum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clave)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("clave");

                entity.Property(e => e.Estado)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.IdEmpresa).HasColumnName("id_empresa");

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.IdTipoCuenta).HasColumnName("id_tipoCuenta");

                entity.Property(e => e.NumeroCuenta)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("numeroCuenta");

                entity.Property(e => e.Saldo)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("saldo");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__Cuenta__id_empre__403A8C7D");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdPersona)
                    .HasConstraintName("FK__Cuenta__id_perso__3F466844");

                entity.HasOne(d => d.IdTipoCuentaNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdTipoCuenta)
                    .HasConstraintName("FK__Cuenta__id_tipoC__412EB0B6");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("Empresa");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.Ruc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ruc");
            });

            modelBuilder.Entity<Lugare>(entity =>
            {
                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.Distrito)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DISTRITO");

                entity.Property(e => e.TipoA)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Celular)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("celular");

                entity.Property(e => e.Correo)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Dni)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("dni")
                    .IsFixedLength();

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombres");
            });

            modelBuilder.Entity<TipoCuentum>(entity =>
            {
                entity.ToTable("Tipo_Cuenta");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NombreTipoCuenta)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreTipoCuenta");
            });

            modelBuilder.Entity<TipoTransaccion>(entity =>
            {
                entity.ToTable("Tipo_Transaccion");

                entity.HasIndex(e => e.NombreTipoTransaccion, "UQ__Tipo_Tra__F93B579A8A49B2DB")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.NombreTipoTransaccion)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nombreTipoTransaccion");
            });

            modelBuilder.Entity<Transaccion>(entity =>
            {
                entity.ToTable("Transaccion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdCuenta).HasColumnName("id_cuenta");

                entity.Property(e => e.IdOrigen).HasColumnName("id_origen");

                entity.Property(e => e.IdTipoTransaccion).HasColumnName("id_tipoTransaccion");

                entity.Property(e => e.Monto)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("monto");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Transaccions)
                    .HasForeignKey(d => d.IdCuenta)
                    .HasConstraintName("FK__Transacci__id_cu__46E78A0C");

                entity.HasOne(d => d.IdTipoTransaccionNavigation)
                    .WithMany(p => p.Transaccions)
                    .HasForeignKey(d => d.IdTipoTransaccion)
                    .HasConstraintName("FK__Transacci__id_ti__47DBAE45");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PrVeterinaria.Models
{
    public partial class DBContexto : DbContext
    {
        public DBContexto()
            : base("DBContexto")
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }
        public virtual DbSet<DetalleMascota> DetalleMascota { get; set; }
        public virtual DbSet<detalleUsuario> detalleUsuario { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Mascota> Mascota { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<PermisoRol> PermisoRol { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<TipoEstudio> TipoEstudio { get; set; }
        public virtual DbSet<TipoMascota> TipoMascota { get; set; }
        public virtual DbSet<TipoPago> TipoPago { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.nombreCliente)
                .IsFixedLength();

            modelBuilder.Entity<Clientes>()
                .Property(e => e.numeroDocumento)
                .IsFixedLength();

            modelBuilder.Entity<Clientes>()
                .Property(e => e.correo)
                .IsFixedLength();

            modelBuilder.Entity<Clientes>()
                .Property(e => e.direccion)
                .IsFixedLength();

            modelBuilder.Entity<Clientes>()
                .Property(e => e.ciudad)
                .IsFixedLength();

            modelBuilder.Entity<DetalleMascota>()
                .Property(e => e.nombreDetalle)
                .IsFixedLength();

            modelBuilder.Entity<DetalleMascota>()
                .HasOptional(e => e.DetalleMascota1)
                .WithRequired(e => e.DetalleMascota2);

            modelBuilder.Entity<detalleUsuario>()
                .Property(e => e.Titulo)
                .IsFixedLength();

            modelBuilder.Entity<detalleUsuario>()
                .HasOptional(e => e.detalleUsuario1)
                .WithRequired(e => e.detalleUsuario2);

            modelBuilder.Entity<Mascota>()
                .Property(e => e.nombreMascota)
                .IsFixedLength();

            modelBuilder.Entity<Mascota>()
                .Property(e => e.raza)
                .IsFixedLength();

            modelBuilder.Entity<Permiso>()
                .Property(e => e.nombrePermiso)
                .IsFixedLength();

            modelBuilder.Entity<Producto>()
                .Property(e => e.nombre)
                .IsFixedLength();

            modelBuilder.Entity<Rol>()
                .Property(e => e.nombreRol)
                .IsFixedLength();

            modelBuilder.Entity<TipoDocumento>()
                .Property(e => e.descripcion)
                .IsFixedLength();

            modelBuilder.Entity<TipoEstudio>()
                .Property(e => e.NombreTipo)
                .IsFixedLength();

            modelBuilder.Entity<TipoMascota>()
                .Property(e => e.nombre)
                .IsFixedLength();

            modelBuilder.Entity<TipoPago>()
                .Property(e => e.nombre)
                .IsFixedLength();

            modelBuilder.Entity<TipoProducto>()
                .Property(e => e.descripcion)
                .IsFixedLength();

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.nombre)
                .IsFixedLength();

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.contraseña)
                .IsFixedLength();

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.numeroDocumentro)
                .IsFixedLength();

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.correo)
                .IsFixedLength();

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.direccion)
                .IsFixedLength();
        }
    }
}

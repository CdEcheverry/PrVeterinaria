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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

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

    }
}

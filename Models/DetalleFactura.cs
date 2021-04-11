namespace PrVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetalleFactura")]
    public partial class DetalleFactura
    {
        [Key]
        public int id_detalleFactura { get; set; }

        public int id_factura { get; set; }

        public int id_producto { get; set; }

        public decimal precio { get; set; }

        public int cantidad { get; set; }

        public virtual Factura Factura { get; set; }

        public virtual Producto Producto { get; set; }
    }
}

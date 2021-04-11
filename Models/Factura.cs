namespace PrVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Factura")]
    public partial class Factura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Factura()
        {
            DetalleFactura = new HashSet<DetalleFactura>();
        }

        [Key]
        public int id_factura { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        [Display(Name = "Cliente")]
        public int id_Cliente { get; set; }

        [Display(Name = "Forma de Pago")]
        public int id_tipoPago { get; set; }

        public virtual Clientes Clientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleFactura> DetalleFactura { get; set; }

        public virtual TipoPago TipoPago { get; set; }
    }
}

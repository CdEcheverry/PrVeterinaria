namespace PrVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetalleMascota")]
    public partial class DetalleMascota
    {
        [Key]
        public int id_detalleMascota { get; set; }

        [StringLength(30)]
        public string nombreDetalle { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha { get; set; }

        public int? id_mascota { get; set; }

        public virtual Mascota Mascota { get; set; }
    }
}

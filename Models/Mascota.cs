namespace PrVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mascota")]
    public partial class Mascota
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mascota()
        {
            DetalleMascota = new HashSet<DetalleMascota>();
        }

        [Key]
        public int id_mascota { get; set; }

        [StringLength(20)]
        public string nombreMascota { get; set; }

        [StringLength(20)]
        public string raza { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha_nacimiento_mascota { get; set; }

        public int? id_tipoMascota { get; set; }

        public int? id_Cliente { get; set; }

        public virtual Clientes Clientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleMascota> DetalleMascota { get; set; }

        public virtual TipoMascota TipoMascota { get; set; }
    }
}

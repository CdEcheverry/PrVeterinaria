namespace PrVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("detalleUsuario")]
    public partial class detalleUsuario
    {
        [Key]
        public int id_detalleUsuario { get; set; }

        public int? id_usuario { get; set; }

        public int? id_tipoEstudio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaInicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaFin { get; set; }

        [StringLength(25)]
        public string Titulo { get; set; }

        public virtual detalleUsuario detalleUsuario1 { get; set; }

        public virtual detalleUsuario detalleUsuario2 { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}

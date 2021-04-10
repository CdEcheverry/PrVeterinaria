namespace PrVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TipoEstudio")]
    public partial class TipoEstudio
    {

        public TipoEstudio()
        {
            detalleUsuario = new HashSet<detalleUsuario>();        
        }

        [Key]
        public int id_tipoEstudio { get; set; }

        [StringLength(100)]
        public string NombreTipo { get; set; }

        public virtual ICollection<detalleUsuario> detalleUsuario { get; set; }
    }
}

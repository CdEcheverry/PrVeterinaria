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
        [Key]
        public int id_tipoEstudio { get; set; }

        [StringLength(10)]
        public string NombreTipo { get; set; }
    }
}

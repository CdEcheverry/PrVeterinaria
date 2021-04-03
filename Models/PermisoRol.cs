using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrVeterinaria.Models
{
 
    [Table("PermisoRol")]
    public partial class PermisoRol
    {
        [Key]
        public int id { get; set; }

        public int? id_rol { get; set; }

        public int? id_permiso { get; set; }

        [JsonIgnore]
        public virtual Permiso Permiso { get; set; }

        [JsonIgnore]
        public virtual Rol Rol { get; set; }
    }
}

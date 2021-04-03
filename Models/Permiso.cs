namespace PrVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permiso")]
    public partial class Permiso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Permiso()
        {
            PermisoRol = new HashSet<PermisoRol>();
        }

        [Key]
        public int id_permiso { get; set; }

        [StringLength(20)]
        public string nombrePermiso { get; set; }

        public virtual ICollection<PermisoRol> PermisoRol { get; set; }
    }
}

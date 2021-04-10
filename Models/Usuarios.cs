namespace PrVeterinaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Threading.Tasks;

    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            detalleUsuario = new HashSet<detalleUsuario>();
        }

        [Key]
        public int id_usuario { get; set; }

        [StringLength(20)]
        public string nombre { get; set; }

        [StringLength(20)]
        public string contraseña { get; set; }

        public int? id_tipoDocumento { get; set; }

        [StringLength(10)]
        public string numeroDocumentro { get; set; }

        [StringLength(20)]
        public string correo { get; set; }

        [StringLength(20)]
        public string direccion { get; set; }

        public int id_rol { get; set; }

        public int? telefono { get; set; }

        public string UserProfile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalleUsuario> detalleUsuario { get; set; }

        public virtual Rol Rol { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }


        public static implicit operator Usuarios(Task<Usuarios> v)
        {
            throw new NotImplementedException();
        }
    }
}

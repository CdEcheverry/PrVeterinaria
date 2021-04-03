using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrVeterinaria.Models.ViewModel
{
    public class Nuevo
    {      
        [Display(Name = "Id Usuarios")]
        [MaxLength(50)]
        public string idUsuario { get; set; }

        [Display(Name = "Password")]
        [MaxLength(250)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(150)]
        [Required]
        public string nombre { get; set; }

        [Display(Name = "Direccion")]
        [MaxLength(150)]
        public string direccion { get; set; }

        [Display(Name = "Teléfono")]
        [MaxLength(20)]
        [Phone]
        public string telefono { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Permiso Asignado")]
        public string idRol { get; set; }
    }
    public class listaUsuario
    {
        
        public string idUsuario { get; set; }

        [Display(Name = "Email")]        
        public string email { get; set; }

        [Display(Name = "Nombre")]      
        public string nombre { get; set; }

        [Display(Name = "Rol Asignado")]
        public string rolusuario { get; set; }
       
        public bool activo { get; set; }
    }

    public class EditarUsuario
    {
        [Key]
        [Required]
        public string idUsuario { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [Required]
        [MaxLength(255)]
        public string email { get; set; }

        [Display(Name = "Permiso Asignado")]
        public string idRol { get; set; }
    }

    public class LogIn
    {
        [Display(Name = "Usuario")]
        [Required]
        public string usuario { get; set; }

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }

    public class RecuperarPassword
    {
        [Display(Name = "Usuario")]
        [Required]
        public string usuario { get; set; }
    }

    public class CambiarPassword
    {
        [Display(Name = "Password Actual")]
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Nuevo Password")]
        [Required]
        [DataType(DataType.Password)]
        [MinLength(5)]
        public string newPassword { get; set; }

        [Display(Name = "Confirmar Password")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("newPassword")]
        public string confirmPassword { get; set; }
    }

    public class Rolconsulta
    {
        public int id_rol { get; set; }
        public string nombreRol { get; set; }
    }

    public class TipoDocumentoDTO
    {
        public int id_tipoDocumento { get; set; }
        public string descripcion { get; set; }
    }

    public class TipoPagoDTO
    {
        public int id_tipoPago { get; set; }

        public string nombre { get; set; }
    }

    public class Permisoconsulta
    {
        public int id_permiso { get; set; }
        public string nombrePermiso { get; set; }
    }

    public class RolPermiso
    {
        public int id_permiso { get; set; }
        public int id_rol { get; set; }
        public string nombreRol { get; set; }
        public string nombrePermiso { get; set; }
    }
}
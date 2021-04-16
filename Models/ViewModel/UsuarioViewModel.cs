using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrVeterinaria.Models.ViewModel
{
    public class Nuevo
    {      
        [Display(Name = "UserProfile")]
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

        [Display(Name = "Ciudad")]
        public string ciudad { get; set; }

        [Display(Name = "Rol Asignado")]
        public int id_rol { get; set; }

        [Display(Name = "Tipo Documento")]
        public int tipoDoc { get; set; }

        [Display(Name = "Numero Documento")]
        public string numeroDocumento { get; set; }
        
    }
    public class listaUsuario
    {
        public int id { get; set; }
        public string idUsuario { get; set; }

        [Display(Name = "Email")]        
        public string email { get; set; }

        [Display(Name = "Nombre")]      
        public string nombre { get; set; }

        [Display(Name = "Rol Asignado")]
        public string rolusuario { get; set; }
       
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

    public class ViewReporteFecha
    {
        [DataType(DataType.Date)]
        public DateTime fechaInicial { get; set; }
        [DataType(DataType.Date)]
        public DateTime fechaFinal { get; set; }
    }

    public class listaClientes
    {
        public int id_Cliente { get; set; }

        public string tipoDocumento { get; set; }

        public string numeroDocumento { get; set; }

        public string telefono { get; set; }

        public string ciudad { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Nombre")]
        public string nombre { get; set; }
    }

    public class MascotaDTO
    {
        public int id_mascota { get; set; }

        public string nombreMascota { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime fecha_nacimiento_mascota { get; set; }
        public string dueño { get; set; }

        public int edad { get; set;}
        public string raza { get; set; }
        public string especie { get; set; }

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

    public class DetalleMascotaDTO
    {
        [Display(Name = "id")]
        public int id_detalleMascota { get; set; }

        [Display(Name = "Diagnostico")]
        public string nombreDetalle { get; set; }

        [Display(Name = "Fecha de Consulta")]
        public DateTime fecha { get; set; }

        public int id_mascota { get; set; }
    }

    public class VentaViewModel
    {
        public int id_factura { get; set; }

        public int id_producto { get; set; }

        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }

        [Display(Name = "Precio")]
        public decimal precio { get; set; }
        public string producto { get; set; }

        [Display(Name = "Numero De Documento")]
        [Required]
        public string id_Cliente { get; set; }

        [Display(Name = "Pago")]
        public string id_tipoPago { get; set; }
    }

    public class VentaReporte
    {
        public int id_factura { get; set; }
        public decimal precio { get; set; }
        public string articulo { get; set; }
        public DateTime fecha { get; set; }
        public string tipoPago { get; set; }
        public int cantidad { get; set; }            
        public string nombreCliente { get; set; }          
        public string Direccion { get; set; }
        public string ciudad { get; set; }
        public string TipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public decimal Total { get; set; }

        public decimal TotalFactura { get; set; }

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

    public class TipoMascotaDTO
    {
        public int id_tipoMascota { get; set; }

        public string nombre { get; set; }
    }

    public class TipoProductoDTO
    {
        public int id_tipoProducto { get; set; }

        public string descripcion { get; set; }
    }

    public class TipoEstudioDTO
    {
        public int id_tipoEstudio { get; set; }

        public string NombreTipo { get; set; }
    }

    public class ProductoDTO
    {
        public int id_tipoProducto { get; set; }

        public string nombre { get; set; }

        public decimal precio { get; set; }

        public int id { get; set; }
    }

    public class Permisoconsulta
    {
        public int id_permiso { get; set; }
        public string nombrePermiso { get; set; }
    }

    public class DetalleUsuarioDTO
    {
        public int id_usuario { get; set; }
        public int id_detalleUsuario { get; set; }


        [Display(Name = "Grado de Escolaridad")]
        public string tipoEstudio { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fechai Inicio")]
        public DateTime? FechaInicio { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha Finalizaciòn")]
        public DateTime? FechaFin { get; set; }

        [StringLength(25)]
        [Display(Name = "Titulo Obtenido")]
        public string Titulo { get; set; }
    }

    public class RolPermiso
    {
        public int id_permiso { get; set; }
        public int id_rol { get; set; }
        public string nombreRol { get; set; }
        public string nombrePermiso { get; set; }
    }
}
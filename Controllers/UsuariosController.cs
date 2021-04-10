using PrVeterinaria.Libs;
using PrVeterinaria.Models;
using PrVeterinaria.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrVeterinaria.Controllers
{
    public class UsuariosController : Controller
    {
        DBContexto _db = new DBContexto();
        // GET: Usuarios
        [Authentication("USUARIOS")]
        public ActionResult Index()
        {
            var usuarios  = _db.Usuarios.Select(user =>
                        new listaUsuario
                        {
                            idUsuario = user.UserProfile,
                            rolusuario = user.Rol.nombreRol,
                            email=user.correo,
                            id=user.id_usuario
                        }).ToList();

            ViewBag.ListaUsuario = usuarios;
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
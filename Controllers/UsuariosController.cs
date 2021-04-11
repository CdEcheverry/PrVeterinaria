using PrVeterinaria.Libs;
using PrVeterinaria.Models;
using PrVeterinaria.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            var usuarios = _db.Usuarios.Select(user =>
                       new listaUsuario
                       {
                           idUsuario = user.UserProfile,
                           rolusuario = user.Rol.nombreRol,
                           email = user.correo,
                           id = user.id_usuario
                       }).ToList();

            ViewBag.ListaUsuario = usuarios;
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Rol = new SelectList(_db.Rol, "id_rol", "nombreRol");
            ViewBag.TipoDoc = new SelectList(_db.TipoDocumento, "id_tipoDocumento", "descripcion");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Nuevo nuevo)
        {
            Usuarios NewUser = new Usuarios();
            NewUser.id_rol = nuevo.id_rol;
            NewUser.direccion = nuevo.direccion;
            NewUser.correo = nuevo.email;
            NewUser.contraseña = nuevo.password;
            NewUser.telefono = nuevo.telefono;
            NewUser.UserProfile = nuevo.idUsuario;
            NewUser.numeroDocumentro = nuevo.numeroDocumento;
            NewUser.id_tipoDocumento = nuevo.tipoDoc;
            NewUser.nombre = nuevo.nombre;

            _db.Usuarios.Add(NewUser);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            detalleUsuario details = new detalleUsuario();

            details.id_usuario = id ?? 0;
            var DetalleUsuario = _db.detalleUsuario.Select(p =>
                       new DetalleUsuarioDTO
                       {
                           id_usuario = p.id_usuario,
                           id_detalleUsuario = p.id_detalleUsuario,
                           Titulo = p.Titulo,
                           tipoEstudio = p.TipoEstudio.NombreTipo,
                           FechaInicio = p.FechaInicio,
                           FechaFin = p.FechaFin
                       }).Where(x => x.id_usuario == id).ToList(); ;

            ViewBag.TipoEstudio = new SelectList(_db.TipoEstudio, "id_tipoEstudio", "NombreTipo");

            ViewBag.detalle = DetalleUsuario;
            return View(details);
        }

        [HttpPost]
        public ActionResult Detalle(detalleUsuario detalle)
        {
            _db.detalleUsuario.Add(detalle);
            _db.SaveChanges();
            return RedirectToAction("Detalle", new { id = detalle.id_usuario});
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios editUser = _db.Usuarios.Find(id);

            ViewBag.Rol = new SelectList(_db.Rol, "id_rol", "nombreRol");
            ViewBag.TipoDoc = new SelectList(_db.TipoDocumento, "id_tipoDocumento", "descripcion");
            return View(editUser);
        }


        [HttpPost]
        public ActionResult Edit(Usuarios edit)
        {
            Usuarios tblUsuario = _db.Usuarios.Find(edit.id_usuario);
            tblUsuario.correo = edit.correo;
            tblUsuario.id_rol = edit.id_rol;
            tblUsuario.direccion = edit.direccion;
            tblUsuario.telefono = edit.telefono;

            _db.Entry(tblUsuario).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Edit", new { id = edit.id_usuario });
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
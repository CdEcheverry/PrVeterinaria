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
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
    public class ClientesController : Controller
    {
        DBContexto _db = new DBContexto();
        // GET: Usuarios
        [Authentication("CLIENTES")]
        public ActionResult Index()
        {
            var clientes = _db.Clientes.Select(client =>
                       new listaClientes
                       {
                           id_Cliente = client.id_Cliente,
                           nombre = client.nombreCliente,
                           email = client.correo,
                           ciudad = client.ciudad,
                           telefono = client.telefono,
                           tipoDocumento = client.TipoDocumento.descripcion,
                           numeroDocumento = client.numeroDocumento
                       }).ToList();

            ViewBag.listaClientes = clientes;
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.TipoDoc = new SelectList(_db.TipoDocumento, "id_tipoDocumento", "descripcion");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Nuevo nuevo)
        {
            Clientes NewUser = new Clientes();
            NewUser.ciudad = nuevo.ciudad;
            NewUser.correo = nuevo.email;
            NewUser.telefono = nuevo.telefono;
            NewUser.numeroDocumento = nuevo.numeroDocumento;
            NewUser.id_tipoDocumento = nuevo.tipoDoc;
            NewUser.nombreCliente = nuevo.nombre;

            _db.Clientes.Add(NewUser);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes editUser = _db.Clientes.Find(id);

            ViewBag.TipoDoc = new SelectList(_db.TipoDocumento, "id_tipoDocumento", "descripcion");
            return View(editUser);
        }

        [HttpPost]
        public ActionResult Edit(Clientes edit)
        {
            Clientes tblUsuario = _db.Clientes.Find(edit.id_Cliente);
            tblUsuario.correo = edit.correo;
            tblUsuario.ciudad = edit.ciudad;
            tblUsuario.telefono = edit.telefono;

            _db.Entry(tblUsuario).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Edit", new { id = edit.id_Cliente });
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
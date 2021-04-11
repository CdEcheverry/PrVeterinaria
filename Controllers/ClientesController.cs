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
        #region Clientes
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
        #endregion

        #region Mascotas

        public ActionResult IndexMascota()
        {
           var Mascotas = _db.Mascota.Select(m =>
           new MascotaDTO
           {
               id_mascota=m.id_mascota,
               dueño = m.Clientes.nombreCliente,
               nombreMascota = m.nombreMascota,
               fecha_nacimiento_mascota = m.fecha_nacimiento_mascota,
               edad = m.edad,
               raza = m.raza,
               especie = m.TipoMascota.nombre
           }).ToList();

            ViewBag.listaMascotas = Mascotas;
            return View();
        }

        public ActionResult CreateMascota()
        {
            ViewBag.especie = new SelectList(_db.TipoMascota, "id_tipoMascota", "nombre");
            ViewBag.cliente = new SelectList(_db.Clientes, "id_Cliente", "nombreCliente");
            return View();
        }

        [HttpPost]
        public ActionResult CreateMascota(Mascota mascota)
        {
            _db.Mascota.Add(mascota);
            _db.SaveChanges();

            return RedirectToAction("IndexMascota");
        }

        public ActionResult HistorialMascota(int? id)
        {

            DetalleMascota historialClinica = new DetalleMascota();

            historialClinica.id_mascota = id ?? 0;
            var Historial = _db.DetalleMascota.Where(x => x.id_mascota == historialClinica.id_mascota).Select(p =>
                       new DetalleMascotaDTO
                       {
                           id_detalleMascota = p.id_detalleMascota,
                           nombreDetalle = p.nombreDetalle,
                           fecha = p.fecha                        
                       });

            ViewBag.historial = Historial.ToList();
            return View(historialClinica);
        }

        [HttpPost]
        public ActionResult HistorialMascota(DetalleMascota detalle)
        {
            _db.DetalleMascota.Add(detalle);
            _db.SaveChanges();

            return RedirectToAction("HistorialMascota", new { id = detalle.id_mascota});

        }
        #endregion
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
using PrVeterinaria.Models;
using PrVeterinaria.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrVeterinaria.Controllers
{
    public class TipoParametrosController : Controller
    {
        DBContexto _db = new DBContexto();
        // GET: TipoParametros
        public ActionResult TipoDocumento()
        {
            var tipoDocumento = _db.TipoDocumento.Select(p =>
                        new TipoDocumentoDTO
                        {
                            id_tipoDocumento = p.id_tipoDocumento,
                            descripcion = p.descripcion
                        }).ToList();
            ViewBag.TipoDoc = tipoDocumento;
            return View();
        }

        [HttpPost]
        public ActionResult TipoDocumento(TipoDocumentoDTO tipoDocumento)
        {
            if (ModelState.IsValid)
            {
                TipoDocumento nuevoTipo = new TipoDocumento();
                nuevoTipo.descripcion = tipoDocumento.descripcion.ToUpper();
                _db.TipoDocumento.Add(nuevoTipo);
                _db.SaveChanges();

                return RedirectToAction("TipoDocumento");
            }
            else
            {
                return RedirectToAction("TipoDocumento");
            }

        }

        public ActionResult TipoPago()
        {
            var tipoPago = _db.TipoPago.Select(p =>
                       new TipoPagoDTO
                       {
                           id_tipoPago = p.id_tipoPago,
                           nombre = p.nombre
                       }).ToList();
            ViewBag.TipoPag = tipoPago;
            return View();
        }

        [HttpPost]
        public ActionResult TipoPago(TipoPagoDTO tipoPago)
        {
            if (ModelState.IsValid)
            {
                TipoPago nuevoTipo = new TipoPago();
                nuevoTipo.nombre = tipoPago.nombre.ToUpper();
                _db.TipoPago.Add(nuevoTipo);
                _db.SaveChanges();

                return RedirectToAction("TipoPago");
            }
            else
            {
                return RedirectToAction("TipoPago");
            }

        }

        public ActionResult TipoMascota()
        {
            var tipoMascota = _db.TipoMascota.Select(p =>
                       new TipoMascotaDTO
                       {
                           id_tipoMascota = p.id_tipoMascota,
                           nombre = p.nombre
                       }).ToList();
            ViewBag.TipoMas = tipoMascota;
            return View();
        }

        [HttpPost]
        public ActionResult TipoMascota(TipoMascotaDTO tipoMascota)
        {
            if (ModelState.IsValid)
            {
                TipoMascota nuevoTipo = new TipoMascota();
                nuevoTipo.nombre = tipoMascota.nombre.ToUpper();
                _db.TipoMascota.Add(nuevoTipo);
                _db.SaveChanges();

                return RedirectToAction("TipoMascota");
            }
            else
            {
                return RedirectToAction("TipoMascota");
            }

        }

        public ActionResult TipoProducto()
        {
            var tipoProducto = _db.TipoProducto.Select(p =>
                       new TipoProductoDTO
                       {
                           id_tipoProducto = p.id_tipoProducto,
                           descripcion = p.descripcion
                       }).ToList();
            ViewBag.TipoProduc = tipoProducto;
            return View();
        }

        [HttpPost]
        public ActionResult TipoProducto(TipoProductoDTO tipoProducto)
        {
            if (ModelState.IsValid)
            {
                TipoProducto nuevoTipo = new TipoProducto();
                nuevoTipo.descripcion = tipoProducto.descripcion.ToUpper();
                _db.TipoProducto.Add(nuevoTipo);
                _db.SaveChanges();

                return RedirectToAction("TipoProducto");
            }
            else
            {
                return RedirectToAction("TipoProducto");
            }

        }

        public ActionResult TipoEstudio()
        {
            var tipoEstudio = _db.TipoEstudio.Select(p =>
                       new TipoEstudioDTO
                       {
                           id_tipoEstudio = p.id_tipoEstudio,
                           NombreTipo = p.NombreTipo
                       }).ToList();
            ViewBag.TipoEstu = tipoEstudio;
            return View();
        }

        [HttpPost]
        public ActionResult TipoEstudio(TipoEstudioDTO tipoEstudio)
        {
            if (ModelState.IsValid)
            {
                TipoEstudio nuevoTipo = new TipoEstudio();
                nuevoTipo.NombreTipo = tipoEstudio.NombreTipo.ToUpper();
                _db.TipoEstudio.Add(nuevoTipo);
                _db.SaveChanges();

                return RedirectToAction("TipoEstudio");
            }
            else
            {
                return RedirectToAction("TipoEstudio");
            }

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
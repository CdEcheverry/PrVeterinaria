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
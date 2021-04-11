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
    public class ReporteController : Controller
    {
        DBContexto _db = new DBContexto();
        [Authentication("VENTAS")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.cliente = new SelectList(_db.Clientes, "id_Cliente", "nombreCliente");
            ViewBag.tipoPago = new SelectList(_db.TipoPago, "id_tipoPago", "nombre");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Factura factura)
        {
            factura.fecha = DateTime.Now;

            _db.Factura.Add(factura);
            _db.SaveChanges();
            return RedirectToAction("DetalleVenta", new { id = factura.id_factura });
        }

        public ActionResult DetalleVenta(int id)
        {
            try
            {

                Factura detalleFactura = _db.Factura.FirstOrDefault(p => p.id_factura == id);

                VentaViewModel venta = new VentaViewModel();

                venta.id_factura = detalleFactura.id_factura;
                venta.id_Cliente = detalleFactura.Clientes.numeroDocumento;
                venta.id_tipoPago = detalleFactura.TipoPago.nombre;

                ViewBag.Producto = _db.Producto.Select(x => new SelectListItem { Value = x.id_producto.ToString(), Text = x.nombre + " - " + x.precio });

                var detalle = _db.DetalleFactura.Select(m =>
                  new VentaViewModel
                  {
                      id_producto = m.id_producto,
                      id_Cliente = m.Factura.Clientes.nombreCliente,
                      id_tipoPago = m.Factura.TipoPago.nombre,
                      cantidad = m.cantidad,
                      producto = m.Producto.nombre,
                      precio = m.precio
                  }).ToList();

                ViewBag.listaMascotas = detalle;

                return View(venta);
            }
            catch (Exception e)
            {
                return RedirectToAction("Create");
            }
        }

        [HttpPost]
        public ActionResult DetalleVenta(VentaViewModel venta)
        {
            DetalleFactura detalle = new DetalleFactura();

            detalle.id_factura = venta.id_factura;
            detalle.id_producto = venta.id_producto;
            detalle.cantidad = venta.cantidad;
            detalle.precio = _db.Producto.FirstOrDefault(x=> x.id_producto==venta.id_producto).precio;


            _db.DetalleFactura.Add(detalle);
            _db.SaveChanges();
            return RedirectToAction("DetalleVenta", new { id = detalle.id_factura });
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
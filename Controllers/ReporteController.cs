using PrVeterinaria.Libs;
using PrVeterinaria.Models;
using PrVeterinaria.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WinForms;


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

                var detalle = _db.DetalleFactura.Where(x => x.id_factura == id).Select(m =>
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
            detalle.precio = _db.Producto.FirstOrDefault(x => x.id_producto == venta.id_producto).precio;


            _db.DetalleFactura.Add(detalle);
            _db.SaveChanges();
            return RedirectToAction("DetalleVenta", new { id = detalle.id_factura });
        }

        [Authentication("VENTAS")]
        public ActionResult Factura(int id)
        {

            
            LocalReport localReport = new LocalReport();
            string path = Server.MapPath("~/Reportes/Facturas/Factura.rdlc");

            if (System.IO.File.Exists(path))
            {
                localReport.ReportPath = path;
            }
            else
            {
                return RedirectToAction("DetalleVenta", new { id = id });
            }

            var TotalFactura = _db.DetalleFactura.Where(x => x.id_factura == id).ToList();
            decimal total = 0;
            foreach(var i in TotalFactura)
            {
                total += i.precio;
            }
  
            List<VentaReporte> CertificadoVenta = (
                                                    from b in _db.Factura
                                                    join p in _db.DetalleFactura on b.id_factura equals p.id_factura
                                                    join a in _db.Producto on p.id_producto equals a.id_producto
                                                    join r in _db.Clientes on b.id_Cliente equals r.id_Cliente
                                                    where b.id_factura == id
                                                    select new VentaReporte
                                                    {
                                                        id_factura = b.id_factura,
                                                        precio = p.precio,
                                                        articulo = a.nombre,
                                                        fecha = DateTime.Now,
                                                        tipoPago=b.TipoPago.nombre,
                                                        Direccion=r.direccion,
                                                        cantidad = p.cantidad,
                                                        nombreCliente = r.nombreCliente,
                                                        ciudad = r.ciudad,
                                                        TipoDocumento=r.TipoDocumento.descripcion,
                                                        numeroDocumento=r.numeroDocumento,
                                                        Total= p.precio * p.cantidad,
                                                        TotalFactura=total
                                                    }).ToList();


            ReportDataSource certificado = new ReportDataSource("Factura", CertificadoVenta);

            localReport.DataSources.Add(certificado);
            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + reportType + "</OutputFormat>" +
             "  <PageWidth>22,59cm</PageWidth>" +
             "  <PageHeight>29,94cm</PageHeight>" +
             "  <MarginTop>0,00001cm </MarginTop>" +
             "  <MarginLeft>0,00001cm</MarginLeft>" +
             "  <MarginRight>0,00001cm</MarginRight>" +
             "  <MarginBottom>0,00001cm</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;


            renderedBytes = localReport.Render(
            reportType,
            deviceInfo,
                        out mimeType,
                        out encoding,
                        out fileNameExtension,
                        out streams,
                        out warnings);

            return File(renderedBytes, mimeType);
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
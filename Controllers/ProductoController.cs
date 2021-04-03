using PrVeterinaria.Models;
using PrVeterinaria.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrVeterinaria.Controllers
{
    public class ProductoController : Controller
    {
        DBContexto _db = new DBContexto();
        // GET: Producto
        public ActionResult CrearProducto()
        {

            ViewBag.Producto = new SelectList(_db.TipoProducto, "id_tipoProducto", "descripcion");
            var ListaProductos = _db.Producto.Select(p =>
                        new ProductoDTO
                        {
                            nombre = p.nombre,
                            precio = p.precio,
                            id = p.id_producto
                        }).ToList();

            ViewBag.consulta = ListaProductos;
            return View();
        }

        [HttpPost]
        public ActionResult CrearProducto(ProductoDTO productoNuevo)
        {
            Producto productoN = new Producto();
            productoN.nombre = productoNuevo.nombre;
            productoN.precio = productoNuevo.precio;
            productoN.id_tipoProducto = productoNuevo.id_tipoProducto;

            _db.Producto.Add(productoN);
            _db.SaveChanges();

            return RedirectToAction("CrearProducto");

        }

    }
}
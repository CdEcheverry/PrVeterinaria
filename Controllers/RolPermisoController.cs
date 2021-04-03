using PrVeterinaria.Models;
using PrVeterinaria.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrVeterinaria.Controllers
{
    public class RolPermisoController : Controller
    {
        DBContexto _db = new DBContexto();
        public ActionResult Create()
        {
            var roles = _db.Rol.Select(rol =>
                        new Rolconsulta
                        {
                            id_rol = rol.id_rol,
                             nombreRol = rol.nombreRol
                         }).ToList();
            ViewBag.rol = roles;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Rol rol)
        {
            if (ModelState.IsValid)
            {
                _db.Rol.Add(rol);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Rolespermiso(int? id)
        {
            if (id == null)
            {
                Redirect("Index");
            }
            var rol = _db.Rol.Where(x => x.id_rol == id);
            var PermisoRol = _db.PermisoRol.Where(x => x.id_rol == id).ToList();
            ViewBag.Permisos = PermisoRol;
            return View(rol);
        }
    }
}
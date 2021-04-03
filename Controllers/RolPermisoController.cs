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
        public ActionResult CreateRol()
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
        public ActionResult CreateRol(Rolconsulta rol)
        {
            if (ModelState.IsValid)
            {
                Rol nuevoRol = new Rol();
                nuevoRol.nombreRol = rol.nombreRol.ToUpper();
                _db.Rol.Add(nuevoRol);
                _db.SaveChanges();

                return RedirectToAction("CreateRol");
            }
            else
            {
                return RedirectToAction("CreateRol");
            }
        }

        public ActionResult CreatePermiso()
        {
            var permiso = _db.Permiso.Select(p =>
                        new Permisoconsulta
                        {
                            id_permiso = p.id_permiso,
                            nombrePermiso = p.nombrePermiso
                        }).ToList();
            ViewBag.Permiso = permiso;
            return View();
        }

        [HttpPost]
        public ActionResult CreatePermiso(Permisoconsulta permiso)
        {
            if (ModelState.IsValid)
            {
                Permiso nuevoPermiso = new Permiso();
                nuevoPermiso.nombrePermiso = permiso.nombrePermiso.ToUpper();
                _db.Permiso.Add(nuevoPermiso);
                _db.SaveChanges();

                return RedirectToAction("CreatePermiso");
            }
            else
            {
                return RedirectToAction("CreatePermiso");
            }
        }

     
        public ActionResult detalle(int? id)
        {
            if (id == null)
            {
                Redirect("Create");
            }
            var rol = _db.Rol.Where(x => x.id_rol == id).FirstOrDefault();
            RolPermiso rolpermiso = new RolPermiso();
            rolpermiso.id_rol = rol.id_rol;
            rolpermiso.nombreRol = rol.nombreRol;
           
            ViewBag.Permisos = new SelectList(_db.Permiso, "id_permiso", "nombrePermiso");
            var PermisoRol = _db.PermisoRol.Where(x => x.id_rol == id).ToList();

            var consulta = (from pr in _db.PermisoRol
                            join r in _db.Rol on pr.id_rol equals r.id_rol
                            join p in _db.Permiso on pr.id_permiso equals p.id_permiso
                            where  pr.id_rol==id
                            select new RolPermiso
                            {
                                id_permiso=p.id_permiso,
                                nombrePermiso= p.nombrePermiso
                            }).ToList();

            ViewBag.consulta = consulta;
            return View(rolpermiso);
        }

        [HttpPost]
        public ActionResult detalle(RolPermiso rolpermiso)
        {
            PermisoRol permisoRol = new PermisoRol();
            permisoRol.id_rol = rolpermiso.id_rol;
            permisoRol.id_permiso = rolpermiso.id_permiso;

            _db.PermisoRol.Add(permisoRol);
            _db.SaveChanges();

            return RedirectToAction("Detalle", new { id = rolpermiso.id_rol });

        }


    }
}
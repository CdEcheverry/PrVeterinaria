using PrVeterinaria.Libs;
using PrVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
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
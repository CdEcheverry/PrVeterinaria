using PrVeterinaria.Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrVeterinaria.Controllers
{
    public class ReporteController : Controller
    {
        [Authentication("REPORTE")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
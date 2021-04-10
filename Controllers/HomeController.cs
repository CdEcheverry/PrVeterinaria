using PrVeterinaria.Libs;
using PrVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PrVeterinaria.Controllers
{

    public class HomeController : Controller
    {
        DBContexto _db = new DBContexto();

        [Authentication]
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult LogIn(string ReturnUrl = "")
        {
            if (!string.IsNullOrEmpty(ReturnUrl))
            {
                ViewBag.ReturnUrl = ReturnUrl;
            }
            if (Request.IsAuthenticated)
                return RedirectToAction("Index");
            else
                return View();
        }

        [HttpPost]
        public ActionResult LogIn(string usuario, string password, string ReturnUrl)
        {
            Usuarios tblUsuario = _db.Usuarios.Where(s => s.UserProfile == usuario).FirstOrDefault();
            if (tblUsuario != null)
            {
                if (tblUsuario.contraseña.Trim().Equals(password))
                {
                    string nombre = tblUsuario.id_usuario + "@" + tblUsuario.nombre.Trim();
                    FormsAuthentication.SetAuthCookie(nombre, false);

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError("", "Usuario y/o Password incorrectos");

            return View();
        }

        [Authentication]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult RescatarPassword()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RescatarPassword(string usuario)
        {
            Usuarios tblUsuario = await _db.Usuarios.Where(s => s.nombre == usuario.ToUpper()).FirstOrDefaultAsync();
            if (tblUsuario != null)
            {
                string password = GenerarPassword.Generar(10);
                tblUsuario.contraseña = GenerarPassword.GetSHA1(password);
                _db.Entry(tblUsuario).State = EntityState.Modified;
                await EnviarCorreo.Enviar(tblUsuario.correo , "Cambio de contraseña", "Se ha cambiado la contraseña para el usuario " + password);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("LogIn", "Home", new { area = "" });
        }
    }
}
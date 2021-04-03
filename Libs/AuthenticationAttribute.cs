using PrVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace PrVeterinaria.Libs
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class AuthenticationAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        DBContexto db = new DBContexto();
        private string permiso = null;

        public AuthenticationAttribute()
        { }

        public AuthenticationAttribute(string permiso)
        {
            this.permiso = permiso;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);

            if (!skipAuthorization)
                base.OnAuthorization(filterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (HttpContext.Current.Request.IsAuthenticated)
            {
                if (!string.IsNullOrEmpty(permiso))
                {
                    int usuario =int.Parse(HttpContext.Current.User.Identity.Name.Split('@')[0]);
                    try
                    {
                        IQueryable<int> permisos = from s in db.Permiso
                                                   join b in db.PermisoRol on s.id_permiso equals b.id_permiso
                                                   join c in db.Rol on b.id_rol equals c.id_rol
                                                   join d in db.Usuarios on c.id_rol equals d.id_rol
                                                   where d.id_usuario == usuario
                                                         && s.nombrePermiso == permiso.Trim()
                                                   orderby s.id_permiso
                                                   select s.id_permiso;

                        if (permisos.Count() > 0)
                            return true;
                        else
                        {

                            return false;

                        }
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                filterContext.HttpContext.Response.Redirect("~/Home/Error");
            }
            else
            {
                filterContext.HttpContext.Response.Redirect("~/Home/LogIn");
            }

        }

    }
}
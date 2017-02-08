using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using ET;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private UsuarioBL usuarioBl = new UsuarioBL();
        private RolBL rolBL = new RolBL();

        public ActionResult Index()
        {
            return View(usuarioBl.Listar());
        }

        public ActionResult Editar(int id = 0)
        {
            ViewBag.Roles = rolBL.Listar();
            

            return View(id == 0 ? new Usuario() : usuarioBl.GetById(id));

        }

        public ActionResult Guardar(Usuario usuario)
        {
            var result = usuario.Id == 0 ? usuarioBl.Registrar(usuario) : usuarioBl.Actualizar(usuario);
            if (!result)
            {
                ViewBag.Message = "Ocurrio un error inesperado";
                return View("~/Views/Shared/_Mensaje.cshtml");
            }
            return Redirect("~/");
        }

        public ActionResult Eliminar(int id)
        {
            var result = usuarioBl.Eliminar(id);
            if (!result)
            {
                ViewBag.Message = "Ocurrio error inesperado";
                return View("~/Views/Shared/_Mensaje.cshtml");
            }
            return Redirect("~/");
        }
       
    }
}
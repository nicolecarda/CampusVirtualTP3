using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio;
using System.Net;
using System.Net.Http;
using Servicios.Controllers;


namespace WebApp.Controllers
{
    public class NotificacionesController : Controller
    {
        public ActionResult Index()
        {
            return View(Negocio.Notificacion.Listar());
        }

        public ActionResult IndexDos(int idUsuarioEmisor)
        {
            return View(Negocio.Notificacion.ListarPorUsuarioEmisor(idUsuarioEmisor));
        }

        public ActionResult IndexTres(int idUsuarioReceptor)
        {
            return View(Negocio.Notificacion.ListarPorUsuarioEmisor(idUsuarioReceptor));
        }


        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            Negocio.Notificacion.Eliminar(id);
            return RedirectToAction("index");
        }


        [HttpGet]
        public ActionResult ModificarEstado(int id, bool vista)
        {
            Negocio.Notificacion.ModificarEstado(id, vista);
            return RedirectToAction("index");
        }



    }
}
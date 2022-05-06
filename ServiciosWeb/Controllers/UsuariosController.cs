using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiciosWeb.Controllers
{
    public class UsuariosController : ApiController
    {
        [HttpGet]
        public List<Negocio.Usuario> Listar()
        {
            return Negocio.Usuario.Listar();
        }

    }
}

using System.Net;

namespace Servicios.Controllers
{
    public class Respuesta
    {
        public HttpStatusCode Codigo { get; set; }

        public string Mensaje { get; set; }

        public object Datos { get; set; }
    }
}
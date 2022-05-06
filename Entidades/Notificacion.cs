using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Notificacion
    {
           # region Propiedades

        public int IdNotificacion {get; set;} 
        public int IdUsuarioEmisor {get; set;}
        public int IdUsuarioReceptor {get; set;}
        public string Descripcion {get; set;}
        public bool Vista {get; set;}   
        public DateTime Fecha {get; set;}

            #endregion

        }
}

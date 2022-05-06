using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio
{
    public class Notificacion
    {

        #region Metodos

        private static Entidades.Notificacion ArmarDatos(DataRow item)
        {
            Entidades.Notificacion Notificacion = new Entidades.Notificacion();
            Notificacion.IdUsuarioReceptor = Convert.ToInt32(item["IdUsuarioReceptor"]);
            Notificacion.IdUsuarioEmisor = Convert.ToInt32(item["IdUsuarioEmisor"]);
            Notificacion.Descripcion = item["Descripcion"].ToString();
            Notificacion.Vista = Convert.ToBoolean(item["Vista"]);
            Notificacion.Fecha = Convert.ToDateTime(item["Fecha"]);

            return Notificacion;
        }

        public static List<Entidades.Notificacion> Listar()
        {

            DataTable dt = new DataTable();
            dt = Datos.Notificaciones.Listar();

            List<Entidades.Notificacion> listaNotificaciones = new List<Entidades.Notificacion>();

            foreach (DataRow item in dt.Rows)
            {
                listaNotificaciones.Add(ArmarDatos(item));
            }


            return listaNotificaciones;
        }

        public static List<Entidades.Notificacion> ListarPorUsuarioReceptor(int IdUsuarioReceptor)
        {

            DataTable dt = new DataTable();
            dt = Datos.Notificaciones.ListarPorUsuarioReceptor(IdUsuarioReceptor);

            List<Entidades.Notificacion> listaNotificaciones = new List<Entidades.Notificacion>();

            foreach (DataRow item in dt.Rows)
            {
                listaNotificaciones.Add(ArmarDatos(item));
            }


            return listaNotificaciones;
        }

        public static List<Entidades.Notificacion> ListarPorUsuarioEmisor(int IdUsuarioEmisor)
        {

            DataTable dt = new DataTable();
            dt = Datos.Notificaciones.ListarPorUsuarioEmisor(IdUsuarioEmisor);

            List<Entidades.Notificacion> listaNotificaciones = new List<Entidades.Notificacion>();

            foreach (DataRow item in dt.Rows)
            {
                listaNotificaciones.Add(ArmarDatos(item));
            }


            return listaNotificaciones;
        }


        public static int Insertar(Entidades.Notificacion notificacion)

        {
            return Datos.Notificaciones.Insertar(notificacion);

        }

        public static int Modificar(Entidades.Notificacion notificacion)
        {
            Datos.Notificaciones.Modificar(notificacion);

            return notificacion.IdNotificacion;
        }

        public static int Eliminar(int idNotificacion)
        {
            Datos.Notificaciones.Eliminar(idNotificacion);

            return idNotificacion;
        }

        public static int ModificarEstado(int idNotificacion, bool vista)
        {
            Datos.Notificaciones.ModificarEstado(idNotificacion, vista);

            return idNotificacion;
        }


        #endregion
    }
}

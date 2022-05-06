using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Notificaciones
    {
        #region Metodos

        public static DataTable Listar()
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Notificaciones_Listar", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Notificaciones: " + ex.Message);
            }
        }
    

        public static DataTable ListarPorUsuarioReceptor(int IdUsuarioReceptor)
    {
        try
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
            {
                cn.Open();

                // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                SqlCommand cmd = new SqlCommand("SP_Notificaciones_ListarPorUsuarioReceptor", cn);

                // 2. Especifico el tipo de Comando
                cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IdUsuarioReceptor", IdUsuarioReceptor));

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                dt.Load(dataReader);
            }

            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener la lista de Notificaciones por usuario receptor: " + ex.Message);
        }
    }


        public static DataTable ListarPorUsuarioEmisor(int IdUsuarioEmisor)

        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Notificaciones_ListarPorUsuarioEmisor", cn);

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IdUsuarioEmisor", IdUsuarioEmisor));

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Notificaciones por usuario emisor: " + ex.Message);
            }
        }



        public static int Insertar(Entidades.Notificacion notificacion)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Notificaciones_Insertar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdUsuarioEmisor", notificacion.IdUsuarioEmisor));
                    cmd.Parameters.Add(new SqlParameter("@IdUsuarioReceptor", notificacion.IdUsuarioReceptor));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", notificacion.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Vista", notificacion.Vista));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", notificacion.Fecha));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;


                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

                return Convert.ToInt32(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar una notificación: " + ex.Message);
            }
        }

        public static void Modificar(Entidades.Notificacion notificacion)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Notificaciones_Modificar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdNotificacion", notificacion.IdNotificacion));
                    cmd.Parameters.Add(new SqlParameter("@IdUsuarioEmisor", notificacion.IdUsuarioEmisor));
                    cmd.Parameters.Add(new SqlParameter("@IdUsuarioReceptor", notificacion.IdUsuarioReceptor));
                    cmd.Parameters.Add(new SqlParameter("@Descripcion", notificacion.Descripcion));
                    cmd.Parameters.Add(new SqlParameter("@Vista", notificacion.Vista));
                    cmd.Parameters.Add(new SqlParameter("@Fecha", notificacion.Fecha));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;


                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar la notificación: " + ex.Message);
            }
        }

        public static void Eliminar(int idNotificacion)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Notificaciones_Eliminar", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdNotificacion", idNotificacion));

                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Eliminar la notificación: " + ex.Message);
            }
        }

       
        public static void ModificarEstado(int idNotificacion, bool vista)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString))
                {
                    cn.Open();

                    // 1. Creo el objeto SqlCommand y le asigno el nombre del Procedimiento Almacenado
                    SqlCommand cmd = new SqlCommand("SP_Notificaciones_ModificarEstado", cn);

                    //1.A Agregamos parametros a nuestro SP
                    cmd.Parameters.Add(new SqlParameter("@IdNotificacion", idNotificacion));
                    cmd.Parameters.Add(new SqlParameter("@Vista", vista));
                    // 2. Especifico el tipo de Comando
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Ejecuto el comando y asigo el valor al DataReader
                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar el estado de la notificación: " + ex.Message);
            }
        }

        #endregion

    }
}

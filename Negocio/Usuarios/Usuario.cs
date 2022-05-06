using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Usuario
    {
        #region Propiedades
        public int IdUsuario {get;set;}
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Clave { get; set; }
        public int Edad { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Permiso Permiso { get; set; }
        public UsuarioTipo UsuarioTipo { get; set; }
        public EstadoTipo EstadoTipo { get; set; }

        #endregion

        #region Constructor
        public Usuario()
        { }

        public Usuario(int idUsuario, string nombre, string apellido, string email, string direccion, string clave, UsuarioTipo usuarioTipo, int edad, bool activo, Permiso permiso, DateTime fechaNacimiento, EstadoTipo estadoTipo)
        {

            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Email = email;
            this.Direccion = direccion;
            this.Clave = clave;
            this.UsuarioTipo = usuarioTipo;
            this.Edad = edad;
            this.Activo = activo;
            this.Permiso = permiso;
            this.FechaNacimiento = fechaNacimiento;
            this.EstadoTipo = estadoTipo;
        }

        #endregion

        #region Metodos

        public static List<Usuario> Listar()
        {
            List<Usuario> ListaUsuario = new List<Usuario>();

            DataTable dt = Datos.Usuarios.Listar();

            foreach (DataRow dr in dt.Rows)
            {
                ListaUsuario.Add(ArmarDatos(dr));
            }


            return ListaUsuario;
        }

        public static List<Usuario> ListarPorNombre(string nombre)
        {
            List<Usuario> ListaUsuario = new List<Usuario>();

            DataTable dt = Datos.Usuarios.ListarPorNombre(nombre);

            foreach (DataRow dr in dt.Rows)
            {
                ListaUsuario.Add(ArmarDatos(dr));
            }


            return ListaUsuario;
        }

        public static Usuario Obtener(int idPermiso)
        {
            return new Usuario();
        }

        private static Usuario ArmarDatos(DataRow dr)
        {

            Usuario u = new Usuario();
            u.Activo = Convert.ToBoolean(dr["Activo"]);
            u.Apellido = dr["Apellido"].ToString();
            u.Nombre = dr["Nombre"].ToString();

            return u;
        }
        #endregion

    }
}

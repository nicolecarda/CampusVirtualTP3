using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PruebaUnitaria
{
    [TestClass]
    public class Notificacion
    {
        [TestMethod]
        public void Insertar()
        {
            Entidades.Notificacion notificacion = new Entidades.Notificacion();

            
            notificacion.IdUsuarioEmisor = 2;
            notificacion.IdUsuarioReceptor = 1;
            notificacion.Descripcion = "Hola";
            notificacion.Vista = true;
            notificacion.Fecha = DateTime.Now;  

            Negocio.Notificacion.Insertar(notificacion);

        }

        [TestMethod]
        public void Listar()
        {
            Negocio.Notificacion.Listar();
        }

        [TestMethod]
        public void ListarPorUsuarioReceptor()
        {
            Negocio.Notificacion.ListarPorUsuarioReceptor(1);
        }

        [TestMethod]
        public void ListarPorUsuarioEmisor()
        {
            Negocio.Notificacion.ListarPorUsuarioEmisor(2);
        }

        [TestMethod]
        public void Modificar()
        {
            Entidades.Notificacion notificacion = new Entidades.Notificacion();

            notificacion.IdUsuarioEmisor = 2;
            notificacion.IdUsuarioReceptor = 1;
            notificacion.Descripcion = "Chau";
            notificacion.Vista = true;
            notificacion.Fecha = DateTime.Now;

            Negocio.Notificacion.Modificar(notificacion);


        }

        [TestMethod]
        public void ModificarEstado()
        {
            Entidades.Notificacion notificacion = new Entidades.Notificacion();

            Negocio.Notificacion.ModificarEstado(1, true);
        }

        [TestMethod]
        public void Eliminar()
        {
            Negocio.Notificacion.Eliminar(1);
        }

      


    }
}

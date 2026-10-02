using lib_PlataformaStreaming.Entidades;
using lib_PlataformaStreaming.Implementaciones;
using lib_PlataformaStreaming.Interfaces;
using lib_PlataformaStreaming.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebasUnitarias
{
    [TestClass]
    public class ContenidoRepartoPruebas
    {
        private IConexion conexion;
        private ContenidoReparto? entidad = null;

        public ContenidoRepartoPruebas()
        {
            this.conexion = new Conexion();
            conexion.StringConexion = DatosGenerales.StringConexion();
        }

        [TestMethod]
        public void Execute()
        {
            Insertar();
            Consultar();
            Actualizar();
            Borrar();
        }

        public void Insertar()
        {
            var contenido = new PeliculasSeries()
            {
                Titulo = "El juego del calamar",
                Descripcion = "Serie de prueba",
                Tipo = "Serie",
                AnioLanzamiento = 2021,
                ClasificacionEdad = "16+"
            };

            this.conexion.PeliculasSeries!.Add(contenido);

            var persona = new Personas()
            {
                Nombre = "Jung-jae",
                Apellido = "Lee"
            };

            this.conexion.Personas!.Add(persona);

            this.conexion.SaveChanges();

            this.entidad = new ContenidoReparto()
            {
                RolPersona = "Actor",
                NombrePersonaje = "Seong Gi-hun",
                _PeliculaSerie = contenido,
                _Persona = persona
            };

            this.conexion.ContenidoReparto!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.ContenidoReparto!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.NombrePersonaje = "Jugador 456";

            var entry = this.conexion!.Entry<ContenidoReparto>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.ContenidoReparto!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

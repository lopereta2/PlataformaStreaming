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
    public class TemporadasPruebas
    {
        private IConexion conexion;
        private Temporadas? entidad = null;

        public TemporadasPruebas()
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
                Descripcion = "Cientos de jugadores cortos de dinero aceptan una extraña invitación a competir en juegos infantiles." +
                " Adentro les espera un premio irresistible... con un riesgo mortal.",
                Tipo = "Serie",
                AnioLanzamiento = 2021,
                ClasificacionEdad = "16+"
            };

            this.conexion.PeliculasSeries!.Add(contenido);
            this.conexion.SaveChanges();

            this.entidad = new Temporadas()
            {
                Numero = 3,
                Titulo = "Temporada 1",
                _PeliculaSerie = contenido
            };

            this.conexion.Temporadas!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Temporadas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Titulo = "Temporada 3";

            var entry = this.conexion!.Entry<Temporadas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Temporadas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

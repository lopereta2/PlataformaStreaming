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
    public class EpisodiosPruebas
    {
        private IConexion conexion;
        private Episodios? entidad = null;

        public EpisodiosPruebas()
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
                " Adentro les espera un premio irresistible...con un riesgo mortal.",
                Tipo = "Serie",
                AnioLanzamiento = 2021,
                ClasificacionEdad = "16+"
            };

            this.conexion.PeliculasSeries!.Add(contenido);
            this.conexion.SaveChanges();

            var temporada = new Temporadas()
            {
                Numero = 1,
                Titulo = "Temporada 1",
                _PeliculaSerie = contenido
            };

            this.conexion.Temporadas!.Add(temporada);
            this.conexion.SaveChanges();

            this.entidad = new Episodios()
            {
                Numero = 1,
                Titulo = "Luz roja, luz verde",
                Duracion = 1,
                URLArchivoVideo = "PlataformaStreaming.com/co/LuzRojaLuzVerde/81040344",
                _Temporada = temporada
            };

            this.conexion.Episodios!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Episodios!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Titulo = "Episodio Actualizado";

            var entry = this.conexion!.Entry<Episodios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Episodios!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
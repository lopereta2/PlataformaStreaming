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
    public class AudioSubtitulosContenidoPruebas
    {
        private IConexion conexion;
        private AudioSubtitulosContenido? entidad = null;

        public AudioSubtitulosContenidoPruebas()
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
                Descripcion = "Cientos de jugadores cortos de dinero aceptan una extraña invitación a competir en juegos infantiles. "
                + " Adentro les espera un premio irresistible... con un riesgo mortal.",
                Tipo = "Serie",
                AnioLanzamiento = 2021,
                ClasificacionEdad = "16+"
            };

            this.conexion.PeliculasSeries!.Add(contenido);

            var idioma = this.conexion.Idiomas!
                .FirstOrDefault(i => i.CodigoIso == "ES");

            if (idioma == null)
            {
                idioma = new Idiomas()
                {
                    Nombre = "Español",
                    CodigoIso = "ES"
                };

                this.conexion.Idiomas!.Add(idioma);
                this.conexion.SaveChanges();
            }

            this.entidad = new AudioSubtitulosContenido()
            {
                TipoConfig = "Audio",
                _PeliculaSerie = contenido,
                _Idioma = idioma
            };

            this.conexion.AudioSubtitulosContenido!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.AudioSubtitulosContenido!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.TipoConfig = "Subtitulos";

            var entry = this.conexion!.Entry<AudioSubtitulosContenido>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.AudioSubtitulosContenido!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

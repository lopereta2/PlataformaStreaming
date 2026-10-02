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
    public class ContenidoGenerosPruebas
    {
        private IConexion conexion;
        private ContenidoGeneros? entidad = null;

        public ContenidoGenerosPruebas()
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

            var genero = this.conexion.Generos!
                .FirstOrDefault(g => g.Nombre == "K-Drama");

            if (genero == null)
            {
                genero = new Generos()
                {
                    Nombre = "K-Drama"
                };

                this.conexion.Generos!.Add(genero);
                this.conexion.SaveChanges();
            }

            this.entidad = new ContenidoGeneros()
            {
                PeliculaSerieId = contenido.IDContenido,
                GeneroId = genero.IDGenero,
                _PeliculaSerie = contenido,
                _Genero = genero
            };

            this.conexion.ContenidoGeneros!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.ContenidoGeneros!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            var entry = this.conexion!.Entry<ContenidoGeneros>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.ContenidoGeneros!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
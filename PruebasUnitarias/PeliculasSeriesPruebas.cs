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
    public class PeliculasSeriesPruebas
    {
        private IConexion conexion;
        private PeliculasSeries? entidad = null;

        public PeliculasSeriesPruebas()
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
            this.entidad = new PeliculasSeries()
            {
                Titulo = "El juego del calamar",
                Descripcion = "Cientos de jugadores cortos de dinero aceptan una extraña invitación a competir en juegos infantiles." +
                " Adentro les espera un premio irresistible... con un riesgo mortal.",
                Tipo = "Serie",
                AnioLanzamiento = 2021,
                ClasificacionEdad = "16+"
            };
            this.conexion.PeliculasSeries!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.PeliculasSeries!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Titulo = "El juego del calamar 2 - Actualizado";

            var entry = this.conexion!.Entry<PeliculasSeries>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.PeliculasSeries!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

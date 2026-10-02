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
    public class PlanesSuscripcionPruebas
    {
        private IConexion conexion;
        private PlanesSuscripcion? entidad = null;

        public PlanesSuscripcionPruebas()
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
            this.entidad = new PlanesSuscripcion()
            {
                Nombre = "Premium",
                Precio = 40000,
                ResolucionMaxima = "4k",
                PantallasSimultaneas = 6
            };
            this.conexion.PlanesSuscripcion!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.PlanesSuscripcion!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Precio = 42000;

            var entry = this.conexion!.Entry<PlanesSuscripcion>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.PlanesSuscripcion!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

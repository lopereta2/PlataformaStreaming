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
    public class GenerosPruebas
    {
        private IConexion conexion;
        private Generos? entidad = null;

        public GenerosPruebas()
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
            var entidad = this.conexion.Generos!
                .FirstOrDefault(g => g.Nombre == "K-Drama");

            if (entidad == null)
            {
                entidad = new Generos()
                {
                    Nombre = "K-Drama"
                };

                this.conexion.Generos!.Add(entidad);
                this.conexion.SaveChanges();
            }

            this.entidad = entidad;
        }

        public void Consultar()
        {
            var lista = this.conexion.Generos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Acción";

            var entry = this.conexion!.Entry<Generos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Generos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

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
    public class IdiomasPruebas
    {
        private IConexion conexion;
        private Idiomas? entidad = null;

        public IdiomasPruebas()
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
            this.entidad = this.conexion.Idiomas!
            .FirstOrDefault(i => i.CodigoIso == "ES");

            if (this.entidad == null)
            {
                this.entidad = new Idiomas()
                {
                    Nombre = "Español",
                    CodigoIso = "ES"
                };

                this.conexion.Idiomas!.Add(this.entidad);
                this.conexion.SaveChanges();
            }
        }

        public void Consultar()
        {
            var lista = this.conexion.Idiomas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Ingles";
            this.entidad!.CodigoIso = "en";

            var entry = this.conexion!.Entry<Idiomas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Idiomas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

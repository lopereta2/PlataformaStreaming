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
    public class PersonasPruebas
    {
        private IConexion conexion;
        private Personas? entidad = null;

        public PersonasPruebas()
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
            this.entidad = new Personas()
            {
                Nombre = "Jung-jae",
                Apellido = "Lee"
            };
            this.conexion.Personas!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Personas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Peter";
            this.entidad!.Apellido = "Dinklage";

            var entry = this.conexion!.Entry<Personas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Personas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

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
    public class ServidoresCDNPruebas
    {
        private IConexion conexion;
        private ServidoresCDN? entidad = null;

        public ServidoresCDNPruebas()
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
            this.entidad = new ServidoresCDN()
            {
                Nombre = "StreamingServer",
                EspacioGeografico = "Medellin de Norte",
                Estado = "Activo",
            };
            this.conexion.ServidoresCDN!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.ServidoresCDN!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Estado = "Mantenimiento";

            var entry = this.conexion!.Entry<ServidoresCDN>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.ServidoresCDN!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

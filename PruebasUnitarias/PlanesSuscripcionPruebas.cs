using lib_PlataformaStreaming.Entidades;
using lib_PlataformaStreaming.Implementaciones;
using lib_PlataformaStreaming.Interfaces;
using lib_PlataformaStreaming.Nucleo;
using Microsoft.EntityFrameworkCore;

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
            using var transaction =
                ((DbContext)this.conexion).Database.BeginTransaction();

            try
            {
                Insertar();
                Consultar();
                Actualizar();
                Borrar();

                transaction.Rollback();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Insertar()
        {
            var existente = this.conexion.PlanesSuscripcion!
                .FirstOrDefault(p => p.Nombre == "PremiumPrueba");

            if (existente != null)
            {
                this.conexion.PlanesSuscripcion!.Remove(existente);
                this.conexion.SaveChanges();
            }

            this.entidad = new PlanesSuscripcion()
            {
                Nombre = "PremiumPrueba",
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

            var entry = this.conexion.Entry<PlanesSuscripcion>(this.entidad);
            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.PlanesSuscripcion!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

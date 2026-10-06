using lib_PlataformaStreaming.Entidades;
using lib_PlataformaStreaming.Implementaciones;
using lib_PlataformaStreaming.Interfaces;
using lib_PlataformaStreaming.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace PruebasUnitarias
{
    [TestClass]
    public sealed class RolesPruebas
    {
        private IConexion conexion;
        private Roles? entidad = null;

        public RolesPruebas()
        {
            this.conexion = new Conexion();
            conexion.StringConexion = DatosGenerales.StringConexion();
        }

        [TestMethod]
        public void Execute()
        {
            using var transaction = ((DbContext)this.conexion).Database.BeginTransaction();

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
            var existente = this.conexion.Roles!
                .FirstOrDefault(r => r.Nombre == "AdministradorPrueba");

            if (existente != null)
            {
                this.conexion.Roles!.Remove(existente);
                this.conexion.SaveChanges();
            }

            this.entidad = new Roles()
            {
                Nombre = "AdministradorPrueba"
            };

            this.conexion.Roles!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Roles!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "UsuarioPrueba";

            var entry = this.conexion!.Entry<Roles>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Roles!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

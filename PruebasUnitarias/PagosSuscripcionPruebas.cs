using lib_PlataformaStreaming.Entidades;
using lib_PlataformaStreaming.Implementaciones;
using lib_PlataformaStreaming.Interfaces;
using lib_PlataformaStreaming.Nucleo;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace PruebasUnitarias
{
    [TestClass]
    public class PagosSuscripcionPruebas
    {
        private IConexion conexion;
        private PagosSuscripcion? entidad = null;

        public PagosSuscripcionPruebas()
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
            var rol = this.conexion.Roles!
                .FirstOrDefault(r => r.Nombre == "Usuario");

            if (rol == null)
            {
                rol = new Roles()
                {
                    Nombre = "Usuario"
                };

                this.conexion.Roles!.Add(rol);
                this.conexion.SaveChanges();
            }

            var usuario = this.conexion.Usuarios!
                .FirstOrDefault(u => u.Correo == "Lucia@gmail.com");

            if (usuario == null)
            {
                usuario = new Usuarios()
                {
                    Nombre = "Lucia",
                    Correo = "Lucia@gmail.com",
                    Contraseña = Encoding.UTF8.GetBytes("123456"),
                    FechaRegistro = new DateTime(2024, 07, 24),
                    _Rol = rol
                };

                this.conexion.Usuarios!.Add(usuario);
                this.conexion.SaveChanges();
            }

            var plan = this.conexion.PlanesSuscripcion!
                .FirstOrDefault(p => p.Nombre == "Premium");

            if (plan == null)
            {
                throw new Exception("No existe el plan Premium");
            }

            this.entidad = new PagosSuscripcion()
            {
                Monto = 40000,
                FechaPago = new DateTime(2026, 05, 18),
                EstadoPago = "Aprobado",
                _Usuario = usuario,
                _PlanSuscripcion = plan
            };

            this.conexion.PagosSuscripcion!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.PagosSuscripcion!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.EstadoPago = "Pendiente";

            var entry = this.conexion.Entry<PagosSuscripcion>(this.entidad);
            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.PagosSuscripcion!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

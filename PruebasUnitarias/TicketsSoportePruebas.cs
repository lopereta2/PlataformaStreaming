using lib_PlataformaStreaming.Entidades;
using lib_PlataformaStreaming.Implementaciones;
using lib_PlataformaStreaming.Interfaces;
using lib_PlataformaStreaming.Nucleo;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace PruebasUnitarias
{
    [TestClass]
    public class TicketsSoportePruebas
    {
        private IConexion conexion;
        private TicketsSoporte? entidad = null;

        public TicketsSoportePruebas()
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

            var usuario = new Usuarios()
            {
                Nombre = "Eliza",
                Correo = "Eliza@gmail.com",
                Contraseña = Encoding.UTF8.GetBytes("ElizaPS3-54sS"),
                FechaRegistro = new DateTime(2025, 12, 01),
                _Rol = rol
            };

            this.conexion.Usuarios!.Add(usuario);
            this.conexion.SaveChanges();

            this.entidad = new TicketsSoporte()
            {
                Asunto = "Error de Inicio de Sesion",
                Descripcion = "Al querer iniciar sesion me sale una alerta que dice: " + "Error de Inicio de Sesion",
                Estado = "Resuelto",
                Fecha = new DateTime(2025, 04, 01),
                _Usuario = usuario
            };
            this.conexion.TicketsSoporte!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.TicketsSoporte!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Estado = "En proceso";

            var entry = this.conexion!.Entry<TicketsSoporte>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.TicketsSoporte!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

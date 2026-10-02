using lib_PlataformaStreaming.Entidades;
using lib_PlataformaStreaming.Implementaciones;
using lib_PlataformaStreaming.Interfaces;
using lib_PlataformaStreaming.Nucleo;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace PruebasUnitarias
{
    [TestClass]
    public class DispositivosConectadosPruebas
    {
        private IConexion conexion;
        private DispositivosConectados? entidad = null;

        public DispositivosConectadosPruebas()
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
                Nombre = "Conni",
                Correo = "Conni@gmail.com",
                Contraseña = Encoding.UTF8.GetBytes("12Zsg33_saZ"),
                FechaRegistro = new DateTime(2025, 12, 01),
                _Rol = rol
            };

            this.conexion.Usuarios!.Add(usuario);
            this.conexion.SaveChanges();

            var perfil = new Perfiles()
            {
                Nombre = "PerfilConni",
                AvatarURL = "https://avatar.com/4",
                EsInfantil = false,
                _Usuario = usuario
            };

            this.conexion.Perfiles!.Add(perfil);
            this.conexion.SaveChanges();

            this.entidad = new DispositivosConectados()
            {
                Nombre = "Elver",
                Tipo = "TV",
                TokenSesion = "JWT.HS256(Elver, dr212sGSAz)",
                UltimoAcceso = new DateTime(2026, 09, 04),
                _Usuario = usuario
            };
            this.conexion.DispositivosConectados!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.DispositivosConectados!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Móvil";

            var entry = this.conexion!.Entry<DispositivosConectados>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.DispositivosConectados!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

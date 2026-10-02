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
    public class PerfilesPruebas
    {
        private IConexion conexion;
        private Perfiles? entidad = null;

        public PerfilesPruebas()
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
            .FirstOrDefault(r => r.Nombre == "Administrador");

            if (rol == null)
            {
                rol = new Roles()
                {
                    Nombre = "Administrador"
                };

                this.conexion.Roles!.Add(rol);
                this.conexion.SaveChanges();
            }

            this.conexion.Roles!.Add(rol);
            this.conexion.SaveChanges();

            var usuario = new Usuarios()
            {
                Nombre = "Invic",
                Correo = "Invic@gmail.com",
                Contraseña = Encoding.UTF8.GetBytes("2f1a3V"),
                FechaRegistro = new DateTime(2022, 11, 15),
                _Rol = rol
            };

            this.conexion.Usuarios!.Add(usuario);
            this.conexion.SaveChanges();

            this.entidad = new Perfiles()
            {
                Nombre = "Nich",
                AvatarURL = "https:PlatStre12xdz",
                EsInfantil = false,
                _Usuario = usuario
            };
            this.conexion.Perfiles!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Perfiles!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Mich";

            var entry = this.conexion!.Entry<Perfiles>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Perfiles!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
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
    public class MiListaPruebas
    {
        private IConexion conexion;
        private MiLista? entidad = null;

        public MiListaPruebas()
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
                Nombre = "Sandra",
                Correo = "Sandra@gmail.com",
                Contraseña = Encoding.UTF8.GetBytes("12Zsg33_saZ"),
                FechaRegistro = new DateTime(2024, 12, 09),
                _Rol = rol
            };

            this.conexion.Usuarios!.Add(usuario);
            this.conexion.SaveChanges();

            var perfil = new Perfiles()
            {
                Nombre = "PerfilSandra",
                AvatarURL = "https://avatar.com/1",
                EsInfantil = false,
                _Usuario = usuario
            };

            this.conexion.Perfiles!.Add(perfil);

            var contenido = new PeliculasSeries()
            {
                Titulo = "El juego del calamar",
                Descripcion = "Serie de prueba",
                Tipo = "Serie",
                AnioLanzamiento = 2021,
                ClasificacionEdad = "16+"
            };

            this.conexion.PeliculasSeries!.Add(contenido);
            this.conexion.SaveChanges();

            this.entidad = new MiLista()
            {
                Fecha = new DateTime(2025, 09, 30),
                _Perfil = perfil,
                _PeliculaSerie = contenido
            };

            this.conexion.MiLista!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.MiLista!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Fecha = new DateTime(2026, 10, 1);

            var entry = this.conexion!.Entry<MiLista>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.MiLista!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

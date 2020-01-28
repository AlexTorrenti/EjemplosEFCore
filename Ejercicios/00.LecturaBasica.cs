using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFCoreBase.Model;

namespace EFCoreBase
{
    public class LecturaBasica
    {
        public static void Ejecutar()
        {
            using (var db = new ApplicationDbContext())
            {
                var usuarios = db.Usuarios.ToList();
            }

            // Colecciones
            using (var db = new ApplicationDbContext())
            {
                var usuariosArray = db.Usuarios.ToArray();
                var usuariosDictionary = db.Usuarios.ToDictionary(x => x.ID);
                var usuariosLookup = db.Usuarios.ToLookup(x => x.ID % 2 == 0);
                var usuariosGrouped = db.Usuarios.GroupBy(x => x.ID % 2 == 0);
            }

            // Ordenacion
            using (var db = new ApplicationDbContext())
            {
                // Por Apellidos
                var usuarios = db.Usuarios.OrderBy(x => x.Apellidos).ToList();

                // Primero por Apellidos ASC y luego por Nombre ASC
                var usuarios2 = db.Usuarios
                .OrderBy(x => x.Apellidos).ThenBy(x => x.Nombre).ToList();

                // Primero por Apellidos DESC y luego por Nombre DESC
                var usuarios3 = db.Usuarios
                .OrderByDescending(x => x.Apellidos).ThenByDescending(x => x.Nombre).ToList();
            }

        }

        public List<Usuario> GetUsuarios()
        {
            using (var db = new ApplicationDbContext())
            {
                var usuarios = db.Usuarios.ToList();
                return usuarios;
            }
        }
    }
}

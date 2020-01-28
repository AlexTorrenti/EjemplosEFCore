using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreBase.Model
{
    public class InsercionMultiple
    {
        public static void Ejecutar(bool multiple)
        {
            if (!multiple)
            {
                using (var db = new ApplicationDbContext())
                {
                    // Creamos los usuarios
                    var usuario1 = new Usuario();
                    usuario1.Nombre = "Demorrius";
                    usuario1.Apellidos = "Divs";

                    var usuario2 = new Usuario();
                    usuario2.Nombre = "Elsa";
                    usuario2.Apellidos = "Frozen";

                    // Los añadimos al contexto
                    db.Usuarios.Add(usuario1);
                    db.Add(usuario2); // No es necesario hacerlo al DBSet de usuarios

                    // Persisitimos el contexto
                    db.SaveChanges();
                }
            }
            else
            {
                // Inserción Múltiple
                using (var db = new ApplicationDbContext())
                {
                    var usuario1 = new Usuario();
                    usuario1.Nombre = "Demorrius";
                    usuario1.Apellidos = "Divs";

                    var usuario2 = new Usuario();
                    usuario2.Nombre = "Elsa";
                    usuario2.Apellidos = "Frozen";

                    var usuarios = new List<Usuario>() { usuario1, usuario2 };

                    // Utilizamos AddRange para añadir la lista de usuarios
                    db.Usuarios.AddRange(usuarios);

                    // Persisitimos el contexto               
                    db.SaveChanges();

                }
            }

        }
    }
}

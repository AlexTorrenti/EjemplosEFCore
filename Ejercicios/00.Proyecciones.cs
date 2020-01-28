using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFCoreBase.Model;

namespace EFCoreBase
{
    public class Proyecciones
    {
        public static void Ejecutar()
        {
            // Select aplicado a una columna
            using (var db = new ApplicationDbContext())
            {
                var nombres = db.Usuarios.Select(x => x.Nombre).ToList();
            }

            // Select con varias columnas
            using (var context = new ApplicationDbContext())
            {
                // Proyección a un tipo anónimo
                var estudiantesEnTipoAnonimo = context.Usuarios.Select(x => new { x.ID, x.Nombre }).ToList();

                // Proyección a una clase
                var estudiantesEnClase = context.Usuarios.Select(x => new Usuario { ID = x.ID, Nombre = x.Nombre }).ToList();
            }

        }
    }
}

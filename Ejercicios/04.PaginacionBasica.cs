using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFCoreBase.Model;

namespace EFCoreBase
{
    public class PaginacionBasica
    {
        public static void Ejecutar()
        {
            using (var db = new ApplicationDbContext())
            {
                var pagina = 1;
                var resultadosPorPagina = 10;

                var usuarios = db.Usuarios
            .Skip((pagina - 1) * resultadosPorPagina).Take(resultadosPorPagina).ToList();
            }

        }
    }
}

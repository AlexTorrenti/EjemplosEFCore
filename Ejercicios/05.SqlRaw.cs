using EFCoreBase.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EFCoreBase
{
    public class SqlRaw
    {
        public static void Ejecutar()
        {
            using (var db = new ApplicationDbContext())
            {
                db.Database.ExecuteSqlRaw("delete from Usuarios");
                db.Database.ExecuteSqlRaw("delete from sqlite_sequence where name='Usuarios'");
            }

            using (var db = new ApplicationDbContext())
            {
                var usuarios = db.Usuarios.FromSqlRaw(@"SELECT * FROM Usuarios
                ORDER BY Apellidos DESC LIMIT 10").IgnoreQueryFilters()
                .Select(x => new { x.ID, x.Nombre}).ToList();
            }

            var ID = 3;

            using (var db = new ApplicationDbContext())
            {
                var student = db.Usuarios.
                FromSqlRaw($"SELECT * from Usuarios where ID = {ID}").FirstOrDefault();
            }

        }
    }
}

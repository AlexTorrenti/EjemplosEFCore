using EFCoreBase.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoreBase
{
    public class TiposBorrado
    {
        public static void Ejecutar()
        {
            // Modelo Conectado
            using (var db = new ApplicationDbContext())
            {
                var usuario = db.Usuarios.FirstOrDefault();
                if (usuario != null)
                {                    
                    db.Remove(usuario);
                    db.SaveChanges();
                }
            }

            // Modelo Desconectado
            int IDUsuario = 0;

            using (var db = new ApplicationDbContext())
            {
                IDUsuario = db.Usuarios.Select(x => x.ID).First();
            }

            using (var db = new ApplicationDbContext())
            {
                var usuario = new Usuario();
                usuario.ID = IDUsuario;
                db.Entry(usuario).State = EntityState.Deleted;
                db.SaveChanges();
            }

        }
    }
}

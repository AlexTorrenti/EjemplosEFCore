using EFCoreBase.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCoreBase
{
    public class TiposActualizacion
    {
        public static void Ejecutar()
        {
            // En caso de tener el Modelo Conectado
            using (var db = new ApplicationDbContext())
            {
                var usuario = db.Usuarios.First(x => x.Nombre.StartsWith("Sandra"));
                usuario.Apellidos += " Demorrius";
                db.SaveChanges();
            }

            // Modelo Desconectado con actualización completa (Ver SQL generada)
            Usuario alberta;

            using (var db = new ApplicationDbContext())
            {
                alberta = db.Usuarios.First(x => x.Nombre.StartsWith("Alberta"));
            }

            alberta.Apellidos += " Allen";

            using (var db = new ApplicationDbContext())
            {
                db.Entry(alberta).State = EntityState.Modified;
                db.SaveChanges();
            }

            // Modelo desconectado con actualización parcial
            Usuario mel;

            using (var db = new ApplicationDbContext())
            {
                mel = db.Usuarios.Select(x => new Usuario() { ID = x.ID, Nombre = x.Nombre }).First(x => x.Nombre.StartsWith("Mel"));
            }

            mel.Nombre += " Gibson";

            using (var db = new ApplicationDbContext())
            {
                var entityEntry = db.Attach(mel);
                entityEntry.Property(x => x.Nombre).IsModified = true;
                db.SaveChanges();
            }


        }
    }
}

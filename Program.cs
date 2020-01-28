using System;
using EFCoreBase.Model;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace EFCoreBase
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ApplicationDbContext())
            {
                /*
                var categorias = db.Categorias.ToList();

                foreach (var categoria in categorias)
                    Console.WriteLine(categoria);

    */
                PruebaDia1 pruebaDia1 = new PruebaDia1();         
                // Lazy Loading
                //var curso = db.Cursos.FirstOrDefault();

                //var matriculaciones = curso.Participantes.ToList();

                // Carga los datos de una relación n a n
                //var matriculaciones = db.Matriculaciones.Include(m => m.Curso).Include(m => m.Usuario).ToList();

                // Filtrando
                //var matriculacionesDeAlex = db.Matriculaciones.Where(m => m.UsuarioId == 1).Include(m => m.Curso).ToList();

                // Ignora los Query Filters
                //var todosLosCursos = db.Cursos.IgnoreQueryFilters().ToList();

                // Eager Loading
                //var cursosConParticipantesIncompleta = db.Cursos.Include(c => c.Participantes).ToList();

                // Eager Loading
                //var cursosConParticipantesCompleta = db.Cursos.Include(c => c.Participantes).ThenInclude(m => m.Usuario).ToList();


                // Transacciones
                //Terminal.CreaUsuarioYLoMatricula();

            }
        }

        

        static void CargaInicial()
        {
            using (var db = new ApplicationDbContext())
            {
                using (var fichero = new StreamReader("/Users/alextorrenti/Projects/IFWeb/usuarios.csv"))
                {
                    string linea;

                    int it = 0;
                    while ((linea = fichero.ReadLine()) != null)
                    {
                        Console.WriteLine("Insertando Registro " + it++);
                        Usuario usuario = new Usuario();
                        usuario.Nombre = linea.Split(",")[0];
                        usuario.Apellidos = linea.Split(",")[1];
                        db.Add(usuario);
                    }

                    db.SaveChanges();
                }
            }
        }
    }
}

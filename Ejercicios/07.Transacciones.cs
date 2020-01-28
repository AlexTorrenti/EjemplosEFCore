using System;
using System.Transactions;


namespace EFCoreBase.Model
{
    public class Transacciones
    {
        public static bool CreaUsuarioYLoMatricula()
        {
            bool retorno = false;
            using(var db = new ApplicationDbContext())
            {
                using(var transaction = db.Database.BeginTransaction())
                {                                       
                    var curso = new Curso();
                    curso.Titulo = "Curso EF Core";
                    curso.Activo = true;
                    db.Add(curso);
                    db.SaveChanges();

                    var estudiante = new Estudiante();
                    estudiante.Nombre = "Alex";
                    estudiante.Apellidos = "Torrentí";                    
                    db.Add(estudiante);
                    db.SaveChanges();

                    var matriculacion = new Matriculacion();
                    matriculacion.Curso = curso;
                    matriculacion.Estudiante = estudiante;
                    db.Add(matriculacion);
                    db.SaveChanges();
                    
                    transaction.Commit();
                    retorno = true;
                }
            }
            return retorno;
        }

        public static bool CreaUsuarioYLoMatriculaConScope()
        {
            bool retorno = false;
            Curso curso = null;
            Estudiante estudiante = null;
            using (var scope = new TransactionScope())
            {
                using (var db = new ApplicationDbContext())
                {
                    curso = new Curso();
                    curso.Titulo = "Curso EF Core";
                    curso.Activo = true;
                    db.Add(curso);
                    db.SaveChanges();
                }

                using (var db = new ApplicationDbContext())
                {
                    estudiante = new Estudiante();
                    estudiante.Nombre = "Alex";
                    estudiante.Apellidos = "Torrentí";                   
                    db.Add(estudiante);
                    db.SaveChanges();
                }

                using (var db = new ApplicationDbContext())
                {
                    var matriculacion = new Matriculacion();
                    matriculacion.Curso = curso;
                    matriculacion.Estudiante = estudiante;
                    db.Add(matriculacion);
                    db.SaveChanges();
                }
                scope.Complete();
                retorno = true;                                    
            }
            return retorno;
        }
    }
}




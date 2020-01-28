using System;
namespace EFCoreBase.Model
{
    public class Matriculacion
    {
        public int CursoID { get; set; }
        public virtual Curso Curso { get; set; }
        public int EstudianteID { get; set; }
        public virtual Estudiante Estudiante { get; set; }
    }
}

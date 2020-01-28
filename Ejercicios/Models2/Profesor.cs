using System;

namespace EFCoreBase.Model
{
    public class Profesor : Usuario
    {
        public virtual Curso Curso { get; set; }
        
        public int CursoID { get; set; }
    }
}

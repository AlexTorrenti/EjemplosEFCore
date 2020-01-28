using System;
using System.Collections.Generic;

namespace EFCoreBase.Model
{
    public class Estudiante : Usuario
    {
        public virtual List<Matriculacion> Cursos { get; set; }
    }
}

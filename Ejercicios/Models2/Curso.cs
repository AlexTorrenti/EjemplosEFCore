using System;
using System.Collections.Generic;

namespace EFCoreBase.Model
{
    public class Curso
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public virtual Profesor Profesor { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual List<Matriculacion> Participantes { get; set; }
        public bool Activo { get; set; }
        
    }
}

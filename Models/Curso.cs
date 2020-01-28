using System;
using System.Collections.Generic;

namespace EFCoreBase.ModelSimple
{
    public class Curso
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public int Duracion { get; set; }
        public DateTime FechaAlta { get; set; }
        public List<Usuario> Participantes { get; set; }
    }
}

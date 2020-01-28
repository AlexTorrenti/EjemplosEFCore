using System;
using System.Collections.Generic;

namespace EFCoreBase.ModelSimple
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public Curso Curso { get; set; }
    }
}

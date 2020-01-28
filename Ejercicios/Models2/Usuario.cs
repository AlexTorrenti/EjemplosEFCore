using System;
using System.Collections.Generic;

namespace EFCoreBase.Model
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }        
        public bool EstaActivo { get; set; }
    }
}

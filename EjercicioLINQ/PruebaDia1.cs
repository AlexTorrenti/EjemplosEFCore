using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreBase
{
    public class Persona
    {
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }

    public class PruebaDia1
    {
        public PruebaDia1()
        {            
            List<Persona> personas = new List<Persona>();
            personas.Add(new Persona() { Nombre = "Pepe", FechaNacimiento = new DateTime(2010, 5, 1) });
            personas.Add(new Persona() { Nombre = "Pepe2", FechaNacimiento = new DateTime(2005, 5, 1) });
            personas.Add(new Persona() { Nombre = "Pepe3", FechaNacimiento = new DateTime(2001, 5, 1) });
            personas.Add(new Persona() { Nombre = "Pepe4", FechaNacimiento = new DateTime(2020, 5, 1) });
            personas.Add(new Persona() { Nombre = "Pepe5", FechaNacimiento = new DateTime(2010, 5, 1) });

            var personasOrdenadas = personas.OrderBy(persona => persona.FechaNacimiento);

            foreach(var persona in personasOrdenadas)
            {
                Console.WriteLine(persona.Nombre);
            }
        }

        
    }
}

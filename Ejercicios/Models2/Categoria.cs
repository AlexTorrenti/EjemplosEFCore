using System;
namespace EFCoreBase.Model
{
    public class Categoria
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Activa { get; set; }


        public override string ToString()
        {
            return Nombre;
        }
    }
}

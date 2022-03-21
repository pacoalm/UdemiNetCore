using System;
using Newtonsoft.Json;

namespace console
{
    class Producto {
        public string Nombre {get;set;}
        public decimal Precio {get;set;}
        public string Descripcion {get;set;}
    }
    class Program
    {
       
        static void Main(string[] args)
        {
             Producto prod = new Producto 
            {
                Nombre = "Camisa",
                Precio = 10,
                Descripcion="Tela de algodon"
            };
            string json = JsonConvert.SerializeObject(prod, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}

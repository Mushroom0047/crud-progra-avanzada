using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace trabajoFinal.Models {
    public class Persona {
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Titulo { get; set; }
        public int Edad { get; set; }


        public Persona(string rut, string nombre, string apellido, string titulo, int edad) {
            Rut = rut;
            Nombre = nombre;
            Apellido = apellido;
            Titulo = titulo;
            Edad = edad;
        }
        public Persona() { }
    }
}
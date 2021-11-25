using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Editora { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public string Tipo {
            get {
                return "Livro";
            }
        }
    }
}

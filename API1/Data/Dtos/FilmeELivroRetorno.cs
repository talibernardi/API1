using API1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Data.Dtos
{
    public class FilmeELivroRetorno
    {
        public Filme Filme { get; set; }
        public LivroModel Livro { get; set; }
    }
}

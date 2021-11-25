using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Models
{
    public class FilmeELivroRetorno
    {
        public Filme Filme { get; set; }
        public LivroModel Livro { get; set; }

        public FilmeELivroRetorno(Filme filme, LivroModel livro)
        {
            Filme.Diretor = filme.Diretor;
            Filme.Duracao = filme.Duracao;
            Filme.Genero = filme.Genero;
            Filme.Titulo = filme.Titulo;

            Livro.Editora = livro.Editora;
            Livro.Duracao = livro.Duracao;
            Livro.Genero = livro.Genero;
            Livro.Titulo = livro.Titulo;
        }
    }
}

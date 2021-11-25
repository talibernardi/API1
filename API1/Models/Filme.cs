﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Models
{   
   
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }


        public string Titulo { get; set; }


        public string Diretor { get; set; }

        public string Genero { get; set; }
 
        public int Duracao { get; set; }


        public int IdLivro { get; set; }

        public string Tipo
        {
            get
            {
                return "Filme";
            }
        }
    }
}

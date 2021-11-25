using API1.Data;
using API1.Data.Dtos;
using API1.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Controllers
{
    public class Consulta
    {
        [ApiController]
        [Route("[controller]")]
        public class ConexaoFilmeLivroController : ControllerBase
        {
            private FilmeContext _context;
            private IMapper _mapper;
            public ConexaoFilmeLivroController(FilmeContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            [HttpGet("{id}")]
            public IActionResult RecuperaFilmesPorId(int id)
            {
                Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
                if (filme != null)
                {
                    ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
                    return Ok(filmeDto);
                };

                return NotFound();
            }
        }
    }
}

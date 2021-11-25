using API1.Data;
using API1.Data.Dtos;
using API1.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            var res = await API1.Services.Livro.requisita(filme.IdLivro);

            if (res.IsSuccessStatusCode) {
                _context.Filmes.Add(filme);
                _context.SaveChanges();
                return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme);
            }

            return UnprocessableEntity();
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperaFilmes()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)//classe de entrada (2 propriedades: int, string)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map <ReadFilmeDto>(filme);
                return Ok(filmeDto);
            };
                
            return NotFound();
        }

        [HttpGet("/wiki/{titulo}")]
        public async Task<IActionResult> RecuperaLivrosPorNome(string titulo)
        {
            // Filme
            var filme = _context.Filmes.Where(filme => filme.Titulo.Contains(titulo)).FirstOrDefault();

            if (filme == null) {
                return NoContent();
            }

            ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);

            // Requisicao Livro
            var response = await API1.Services.Livro.requisita(filme.Id);
            var content = await response.Content.ReadAsStringAsync();
            Livro livro = JsonConvert.DeserializeObject<Livro>(content);

            // Lista
            var list = new List<dynamic>();
            list.Add(filme);
            list.Add(livro);

            return Ok(list);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null)
            {
                return NotFound();
            }
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();
        }
        
        [HttpDelete("{id}")]

        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
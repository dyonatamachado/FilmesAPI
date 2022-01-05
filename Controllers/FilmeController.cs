using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.DTO.FilmeDTO;
using FilmesApi.Entities;
using FilmesApi.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public IActionResult ReadFilmes()
        {
            var filmes = _context.Filmes.ToList();
            var filmesDto = new List<ReadFilmeDTO>();

            if(filmes == null)
                return NoContent();
            
            foreach (var filme in filmes)
            {
                var filmeDto = _mapper.Map<ReadFilmeDTO>(filme);
                filmesDto.Add(filmeDto);
            }
            return Ok(filmesDto);
        }

        [HttpGet("{id}")]
        public IActionResult ReadFilmesById(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if(filme == null)
                return NotFound();

            var filmeDto = _mapper.Map<ReadFilmeDTO>(filme);
            return Ok(filmeDto);
        }

        [HttpPost]
        public IActionResult CreateFilme([FromBody] CreateFilmeDTO filmeDto)
        {
            var filme = _mapper.Map<Filme>(filmeDto);

            _context.Add(filme);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ReadFilmesById), new { Id = filme.Id } , filme);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFilme(int id, [FromBody] UpdateFilmeDTO filmeDto)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if(filme == null)
                return NotFound();
            
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if(filme == null)
                return NotFound();
            
            _context.Remove(filme);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")] 
        public IActionResult UpdateCartaz(int id, [FromBody] UpdateCartazDTO cartazDto)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if(filme == null)
                return NotFound();

            _mapper.Map(cartazDto, filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
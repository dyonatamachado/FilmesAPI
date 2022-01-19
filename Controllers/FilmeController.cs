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
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ReadFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<Filme> filmes;

            if(classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.
                    Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            if(filmes == null)
                return NoContent();
            
            var filmesDto = _mapper.Map<List<ReadFilmeDTO>>(filmes);
        
            return Ok(filmesDto);
        }

        [HttpGet("{id}")]
        public IActionResult ReadFilmeById(int id)
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

            return CreatedAtAction(nameof(ReadFilmeById), new { Id = filme.Id } , filme);
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

    }
}
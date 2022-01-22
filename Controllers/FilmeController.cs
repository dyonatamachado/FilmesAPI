using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.DTO.FilmeDTO;
using FilmesApi.Entities;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpGet]
        public IActionResult ReadFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            var filmesDto = _filmeService.ReadFilmes(classificacaoEtaria);

            if(filmesDto == null)
                return NoContent();
                
            return Ok(filmesDto);
        }

        [HttpGet("{id}")]
        public IActionResult ReadFilmeById(int id)
        {
            var filmeDto = _filmeService.ReadFilmeById(id);

            if(filmeDto == null)
                return NotFound();
                
            return Ok(filmeDto);
        }
        
        [HttpPost]
        public IActionResult CreateFilme([FromBody] CreateFilmeDTO dto)
        {
            var filmeDto = _filmeService.CreateFilme(dto);

            return CreatedAtAction(nameof(ReadFilmeById), new { Id = filmeDto.Id } , filmeDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFilme(int id, [FromBody] UpdateFilmeDTO filmeDto)
        {
            var resultado = _filmeService.UpdateFilme(id, filmeDto);

            if(resultado.IsFailed)
                return NotFound();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateCartaz(int id, [FromBody] UpdateCartazDTO cartazDto)
        {
            var resultado = _filmeService.UpdateCartaz(id, cartazDto);
            
            if(resultado.IsFailed)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilme(int id)
        {
            var resultado = _filmeService.DeleteFilme(id);

            if(resultado.IsFailed)
                return NotFound();

            return NoContent();
        }
    }
}
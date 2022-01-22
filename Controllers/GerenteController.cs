using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.DTO.GerenteDTO;
using FilmesApi.Entities;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase 
    {
        private GerenteService _gerenteService;

        public GerenteController(GerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpGet]
        public IActionResult ReadGerentes()
        {
            var gerentesDto = _gerenteService.ReadGerentes();

            if(gerentesDto == null)
                return NoContent();

            return Ok(gerentesDto);
        }

        [HttpGet("{id}")]
        public IActionResult ReadGerenteById(int id)
        {
            var gerenteDto = _gerenteService.ReadGerenteById(id);

            if(gerenteDto == null)
                return NotFound();

            return Ok(gerenteDto);
        }

        [HttpPost]
        public IActionResult CreateGerente([FromBody] CreateGerenteDTO createDto)
        {
            var readDto = _gerenteService.CreateGerente(createDto);
            
            return CreatedAtAction(nameof(ReadGerenteById), new { Id = readDto.Id}, readDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGerente(int id, [FromBody] UpdateGerenteDTO gerenteDto)
        {
            var resultado = _gerenteService.UpdateGerente(id, gerenteDto);
            
            if(resultado.IsFailed)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGerente(int id)
        {
            var resultado = _gerenteService.DeleteGerente(id);

            if(resultado.IsFailed)
                return NotFound();
                
            return NoContent();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.DTO.CinemaDTO;
using FilmesApi.Entities;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;
        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpGet]
        public IActionResult ReadCinemas([FromQuery] string nomeDoFilme)
        {
            var cinemasDto = _cinemaService.ReadCinemas(nomeDoFilme);

            if(cinemasDto == null)
                return NoContent();
            
            return Ok(cinemasDto);
        }

        [HttpGet("{id}")]
        public IActionResult ReadCinemaById(int id)
        {
            var cinemaDto = _cinemaService.ReadCinemaById(id);

            if(cinemaDto == null)
                return NotFound();
            
            return Ok(cinemaDto);
        }

        [HttpPost]
        public IActionResult CreateCinema([FromBody] CreateCinemaDTO createDto)
        {
            var readDto = _cinemaService.CreateCinema(createDto);

            return CreatedAtAction(nameof(ReadCinemaById), new { Id = readDto.Id}, readDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDTO cinemaDto)
        {
            var resultado = _cinemaService.UpdateCinema(id, cinemaDto);
            
            if(resultado.IsFailed)
                return NotFound();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCinema(int id)
        {
            var resultado = _cinemaService.DeleteCinema(id);
            
            if(resultado.IsFailed)
                return NotFound();
            
            return NoContent();

        }
    }
}
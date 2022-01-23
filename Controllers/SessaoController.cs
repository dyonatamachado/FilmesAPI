using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.DTO.SessaoDTO;
using FilmesApi.Entities;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoService _sessaoService;
        public SessaoController(SessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [HttpGet]
        public IActionResult ReadSessoes()
        {
            var sessoesDto = _sessaoService.ReadSessoes();
            
            if(sessoesDto == null)
                return NoContent();

            return Ok(sessoesDto);
        }

        [HttpGet("{id}")]
        public IActionResult ReadSessaoById(int id)
        {
            var sessaoDto =  _sessaoService.ReadSessaoById(id);

            if(sessaoDto == null)
                return NotFound();

            return Ok(sessaoDto);
        }

        [HttpPost]
        public IActionResult CreateSessao([FromBody] CreateSessaoDTO createDto)
        {
            var readDto = _sessaoService.CreateSessao(createDto);

            return CreatedAtAction(nameof(ReadSessaoById), new { Id = readDto.Id}, readDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSessao(int id, [FromBody] UpdateSessaoDTO sessaoDto)
        {
            Result resultado = _sessaoService.UpdateSessao(id, sessaoDto);

            if(resultado.IsFailed)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSessao(int id)
        {
            Result resultado = _sessaoService.DeleteSessao(id);

            if(resultado.IsFailed)
                return NotFound();

            return NoContent();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.DTO.EnderecoDTO;
using FilmesApi.Entities;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public IActionResult ReadEnderecos()
        {
            var enderecosDto = _enderecoService.ReadEnderecos();

            if(enderecosDto == null)
                return NoContent();
            
            return Ok(enderecosDto);
        }

        [HttpGet("{id}")]
        public IActionResult ReadEnderecoById(int id)
        {
            var enderecoDto = _enderecoService.ReadEnderecoById(id);

            if(enderecoDto == null)
                return NotFound();
            
            return Ok(enderecoDto);
        }

        [HttpPost]
        public IActionResult CreateEndereco([FromBody] CreateEnderecoDTO createDto)
        {
            var readDto = _enderecoService.CreateEndereco(createDto);
            
            return CreatedAtAction(nameof(ReadEnderecoById), new { Id = readDto.Id}, readDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEndereco(int id, [FromBody] UpdateEnderecoDTO enderecoDto)
        {
            var resultado = _enderecoService.UpdateEndereco(id, enderecoDto);

            if(resultado.IsFailed)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEndereco(int id)
        {
            var resultado = _enderecoService.DeleteEndereco(id);
            
            if(resultado.IsFailed)
                return NotFound();

            return NoContent();
        }
    }
}
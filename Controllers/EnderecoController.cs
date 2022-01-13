using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.DTO.EnderecoDTO;
using FilmesApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ReadEnderecos()
        {
            var enderecos = _context.Enderecos.ToList();
            if(enderecos.Count == 0)
                return NoContent();
            
            var enderecosDto = new List<ReadEnderecoDTO>();

            foreach (var endereco in enderecos)
            {
               var enderecoDto = _mapper.Map<ReadEnderecoDTO>(endereco);
               enderecosDto.Add(enderecoDto);
            }

            return Ok(enderecosDto);
        }

        [HttpGet("{id}")]
        public IActionResult ReadEnderecoById(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);

            if(endereco == null)
                return NotFound();
            
            var enderecoDto = _mapper.Map<ReadEnderecoDTO>(endereco);
            
            return Ok(enderecoDto);
        }

        [HttpPost]
        public IActionResult CreateEndereco([FromBody] CreateEnderecoDTO enderecoDto)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ReadEnderecoById), new { Id = endereco.Id}, endereco);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateEndereco(int id, [FromBody] UpdateEnderecoDTO enderecoDto)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
            if(endereco == null)
                return NotFound();
            
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEndereco(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
            if(endereco == null)
                return NotFound();

            _context.Remove(endereco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
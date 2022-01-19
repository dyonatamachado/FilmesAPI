using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.DTO.GerenteDTO;
using FilmesApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase 
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ReadGerentes()
        {
            var gerentes = _context.Gerentes.ToList();
            
            if(gerentes.Count == 0)
                return NoContent();
            
            var gerentesDto = _mapper.Map<List<ReadGerenteDTO>>(gerentes);

            return Ok(gerentesDto);
        }

        [HttpGet("{id}")]
        public IActionResult ReadGerenteById(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if(gerente == null)
                return NotFound();
            
            var gerenteDto = _mapper.Map<ReadGerenteDTO>(gerente);

            return Ok(gerenteDto);
        }

        [HttpPost]
        public IActionResult CreateGerente([FromBody] CreateGerenteDTO gerenteDto)
        {
            var gerente = _mapper.Map<Gerente>(gerenteDto);

            _context.Add(gerente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ReadGerenteById), new { Id = gerente.Id}, gerente);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGerente(int id, [FromBody] UpdateGerenteDTO gerenteDto)
        {
            var gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if(gerente == null)
                return NotFound();
            
            _mapper.Map(gerenteDto, gerente);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGerente(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if(gerente == null)
                return NotFound();
            
            _context.Remove(gerente);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
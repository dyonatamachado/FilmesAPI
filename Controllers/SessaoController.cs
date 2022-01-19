using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.DTO.SessaoDTO;
using FilmesApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ReadSessoes()
        {
            var sessoes = _context.Sessoes.ToList();

            if(sessoes.Count == 0)
                return NoContent();

            var sessoesDto = _mapper.Map<List<ReadSessaoDTO>>(sessoes);
            return Ok(sessoesDto);
        }

        [HttpGet("{id}")]
        public IActionResult ReadSessaoById(int id)
        {
            var sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if(sessao == null)
                return NotFound();
            
            var sessaoDto = _mapper.Map<ReadSessaoDTO>(sessao);
            return Ok(sessaoDto);
        }

        [HttpPost]
        public IActionResult CreateSessao([FromBody] CreateSessaoDTO sessaoDto)
        {
            var sessao = _mapper.Map<Sessao>(sessaoDto);
            
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ReadSessaoById), new { Id = sessao.Id}, sessao);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateSessao(int id, [FromBody] UpdateSessaoDTO sessaoDto)
        {
            var sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if(sessao == null)
                return NotFound();
            
            _mapper.Map(sessaoDto, sessao);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSessao(int id)
        {
            var sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if(sessao == null)
                return NotFound();
            
            _context.Remove(sessao);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
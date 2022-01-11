using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.DTO.CinemaDTO;
using FilmesApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ReadCinemas()
        {
            var cinemas = _context.Cinemas.ToList();
            var cinemasDto = new List<ReadCinemaDTO>();

            if(cinemas == null)
                return NoContent();
            
            foreach (var cinema in cinemas)
            {
                var cinemaDto = _mapper.Map<ReadCinemaDTO>(cinema);
                cinemasDto.Add(cinemaDto);
            }

            return Ok(cinemasDto);
        }

        [HttpGet("{id}")]
        public IActionResult ReadCinemaById(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);

            if(cinema == null)
                return NotFound();
            
            var cinemaDto = _mapper.Map<ReadCinemaDTO>(cinema);

            return Ok(cinemaDto);
        }

        [HttpPost]
        public IActionResult CreateCinema([FromBody] CreateCinemaDTO cinemaDto)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDto);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ReadCinemaById), new { Id = cinema.Id}, cinema);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDTO cinemaDto)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);

            if(cinema == null)
                return NotFound();
            
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCinema(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);

            if(cinema == null)
                return NotFound();
            
            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
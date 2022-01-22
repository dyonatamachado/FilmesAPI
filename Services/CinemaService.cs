using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.DTO.CinemaDTO;
using FilmesApi.Entities;
using FluentResults;

namespace FilmesApi.Services
{
    public class CinemaService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadCinemaDTO> ReadCinemas(string nomeDoFilme)
        {
            var cinemas = _context.Cinemas.ToList();
            
            if(!string.IsNullOrEmpty(nomeDoFilme))
            {
                var data = from cinema in cinemas
                    where cinema.Sessoes.Any
                    (sessao => sessao.Filme.Titulo == nomeDoFilme)
                    select cinema;
                
                cinemas = data.ToList();
            }

            if(cinemas.Count != 0)
            {
                var cinemasDto = _mapper.Map<List<ReadCinemaDTO>>(cinemas);
                return cinemasDto;
            }
            
            return null;
        }

        public ReadCinemaDTO ReadCinemaById(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);

            if(cinema != null)
            {
                var cinemaDto = _mapper.Map<ReadCinemaDTO>(cinema);
                return cinemaDto;
            }

            return null;
        
        }

        public ReadCinemaDTO CreateCinema(CreateCinemaDTO createDto)
        {
            var cinema = _mapper.Map<Cinema>(createDto);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            var readDto = _mapper.Map<ReadCinemaDTO>(cinema);
            
            return readDto;
        }

        public Result UpdateCinema(int id, UpdateCinemaDTO cinemaDto)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);

            if(cinema != null)
            {
                _mapper.Map(cinemaDto, cinema);
                _context.SaveChanges();
                return Result.Ok();
            }

            return Result.Fail("Cinema não encontrado");
        }

        public Result DeleteCinema(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);

            if(cinema != null)
            {
                _context.Cinemas.Remove(cinema);
                _context.SaveChanges();
                return Result.Ok();
            }
            
            return Result.Fail("Cinema não encontrado");
        }
    }
}
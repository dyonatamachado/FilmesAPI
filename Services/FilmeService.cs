using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.DTO.FilmeDTO;
using FilmesApi.Entities;
using FluentResults;

namespace FilmesApi.Services
{
    public class FilmeService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public List<ReadFilmeDTO> ReadFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;

            if(classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.
                    Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            if(filmes != null)
            {
                var filmesDto = _mapper.Map<List<ReadFilmeDTO>>(filmes);
                return filmesDto;
            }
            
            return null;
        }

        public ReadFilmeDTO ReadFilmeById(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if(filme != null)
            {
                var filmeDto = _mapper.Map<ReadFilmeDTO>(filme);
                return filmeDto;
            }

            return null;
        }

        public ReadFilmeDTO CreateFilme(CreateFilmeDTO dto)
        {
            var filme = _mapper.Map<Filme>(dto);

            _context.Add(filme);
            _context.SaveChanges();

            var filmeDto = _mapper.Map<ReadFilmeDTO>(filme);

            return filmeDto;
        }

        public Result UpdateFilme(int id, UpdateFilmeDTO filmeDto)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if(filme == null)
                return Result.Fail("Filme não encontrado");
            
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result UpdateCartaz(int id, UpdateCartazDTO cartazDto)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if(filme == null)
                return Result.Fail("Filme não encontrado");
            
            _mapper.Map(cartazDto, filme);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeleteFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if(filme == null)
                return Result.Fail("Filme não encontrado");
            
            _context.Remove(filme);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
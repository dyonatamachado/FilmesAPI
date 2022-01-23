using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.DTO.SessaoDTO;
using FilmesApi.Entities;
using FluentResults;

namespace FilmesApi.Services
{
    public class SessaoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadSessaoDTO> ReadSessoes()
        {
            var sessoes = _context.Sessoes.ToList();

            if(sessoes.Count != 0)
            {
                var sessoesDto = _mapper.Map<List<ReadSessaoDTO>>(sessoes);
                return sessoesDto;
            }

            return null;
        }

        public ReadSessaoDTO ReadSessaoById(int id)
        {
            var sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if(sessao != null)
            {
                var sessaoDto = _mapper.Map<ReadSessaoDTO>(sessao);
                return sessaoDto;
            }
            
            return null;
        }

        public ReadSessaoDTO CreateSessao(CreateSessaoDTO createDto)
        {
            var sessao = _mapper.Map<Sessao>(createDto);
            
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();

            var readDto = _mapper.Map<ReadSessaoDTO>(sessao);

            return readDto;
        }

        public Result UpdateSessao(int id, UpdateSessaoDTO sessaoDto)
        {
            var sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if(sessao != null)
            {
                _mapper.Map(sessaoDto, sessao);
                _context.SaveChanges();

                return Result.Ok();
            }

            return Result.Fail("Sessão não encontrada");
        }

        public Result DeleteSessao(int id)
        {
            var sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if(sessao != null)
            {
                _context.Remove(sessao);
                _context.SaveChanges();
                
                return Result.Ok();
            }

            return Result.Fail("Sessão não encontrada");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.DTO.GerenteDTO;
using FilmesApi.Entities;
using FluentResults;

namespace FilmesApi.Services
{
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadGerenteDTO> ReadGerentes()
        {
            var gerentes = _context.Gerentes.ToList();
            
            if(gerentes.Count != 0)
            {
                var gerentesDto = _mapper.Map<List<ReadGerenteDTO>>(gerentes);
                return gerentesDto;
            }

            return null;
        }

        internal ReadGerenteDTO ReadGerenteById(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if(gerente != null)
            {
                var gerenteDto = _mapper.Map<ReadGerenteDTO>(gerente);
                return gerenteDto;
            }
            
            return null;
        }

        public ReadGerenteDTO CreateGerente(CreateGerenteDTO createDto)
        {
            var gerente = _mapper.Map<Gerente>(createDto);

            _context.Add(gerente);
            _context.SaveChanges();

            var readDto = _mapper.Map<ReadGerenteDTO>(gerente);

            return readDto;
        }

        public Result UpdateGerente(int id, UpdateGerenteDTO gerenteDto)
        {
            var gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if(gerente != null)
            {
                _mapper.Map(gerenteDto, gerente);
                _context.SaveChanges();
                return Result.Ok();
            }            

            return Result.Fail("Gerente não encontrado");
        }

        public Result DeleteGerente(int id)
        {
            var gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if(gerente != null)
            {
                _context.Remove(gerente);
                _context.SaveChanges();
                return Result.Ok();
            }            

            return Result.Fail("Gerente não encontrado");
        }
    }
}
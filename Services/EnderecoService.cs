using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.DTO.EnderecoDTO;
using FilmesApi.Entities;
using FluentResults;

namespace FilmesApi.Services
{
    public class EnderecoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadEnderecoDTO> ReadEnderecos()
        {
            var enderecos = _context.Enderecos.ToList();

            if(enderecos.Count != 0)
            {
                var enderecosDto = _mapper.Map<List<ReadEnderecoDTO>>(enderecos);
                return enderecosDto;
            }

            return null;
        }

        public ReadEnderecoDTO ReadEnderecoById(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);

            if(endereco != null)
            {
                var enderecoDto = _mapper.Map<ReadEnderecoDTO>(endereco);
                return enderecoDto;
            }
            
            return null;
        }

        public ReadEnderecoDTO CreateEndereco(CreateEnderecoDTO createDto)
        {
            var endereco = _mapper.Map<Endereco>(createDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            var readDto = _mapper.Map<ReadEnderecoDTO>(endereco);

            return readDto;
        }

        public Result UpdateEndereco(int id, UpdateEnderecoDTO enderecoDto)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);

            if(endereco != null)
            {
                _mapper.Map(enderecoDto, endereco);
                _context.SaveChanges();
                return Result.Ok();
            }

            return Result.Fail("Endereço não encontrado");            
        }

        public Result DeleteEndereco(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);

            if(endereco != null)
            {
                _context.Remove(endereco);
                _context.SaveChanges();
                return Result.Ok();
            }

            return Result.Fail("Endereço não encontrado"); 
        }
    }
}
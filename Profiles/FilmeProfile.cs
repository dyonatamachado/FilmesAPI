using System;
using AutoMapper;
using FilmesApi.DTO.FilmeDTO;
using FilmesApi.Entities;

namespace FilmesApi.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, Filme>()
                .ForMember(filme => filme.Cartaz,
                map => map.MapFrom(dto => Convert.FromBase64String(dto.CartazBase64)));
            CreateMap<UpdateFilmeDTO, Filme>()
                .ForMember(filme => filme.Cartaz,
                map => map.MapFrom(dto => Convert.FromBase64String(dto.CartazBase64)));
            CreateMap<Filme, ReadFilmeDTO>()
                .ForMember(dto => dto.CartazBase64,
                map => map.MapFrom(filme => Convert.ToBase64String(filme.Cartaz)));
            CreateMap<UpdateCartazDTO, Filme>()
                .ForMember(filme => filme.Cartaz, 
                map => map.MapFrom(dto => Convert.FromBase64String(dto.CartazBase64)));
        }
    }
}
using AutoMapper;
using FilmesApi.DTO.SessaoDTO;
using FilmesApi.Entities;

namespace FilmesApi.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDTO, Sessao>();
            CreateMap<UpdateSessaoDTO, Sessao>();
            CreateMap<Sessao, ReadSessaoDTO>();
        }
    }
}
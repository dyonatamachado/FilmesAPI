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
            CreateMap<Sessao, ReadSessaoDTO>()
                .ForMember(dto => dto.HorarioDeEncerramento, opts => opts
                .MapFrom(dto => dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao * (-1))));
        }
    }
}
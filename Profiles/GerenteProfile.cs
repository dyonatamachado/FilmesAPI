using System.Linq;
using AutoMapper;
using FilmesApi.DTO.GerenteDTO;
using FilmesApi.Entities;

namespace FilmesApi.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDTO, Gerente>();
            CreateMap<UpdateGerenteDTO, Gerente>();
            CreateMap<Gerente, ReadGerenteDTO>()
                .ForMember(gerente => gerente.Cinemas, opts => opts
                .MapFrom(gerente => gerente.Cinemas.Select
                (c => new { c.Id, c.Nome, c.Endereco, c.EnderecoId})));
        }
    }
}
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
            CreateMap<Gerente, ReadGerenteDTO>();
        }
    }
}
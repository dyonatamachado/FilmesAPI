using AutoMapper;
using FilmesApi.DTO.CinemaDTO;
using FilmesApi.Entities;

namespace FilmesApi.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDTO, Cinema>();
            CreateMap<UpdateCinemaDTO, Cinema>();
            CreateMap<Cinema, ReadCinemaDTO>();
        }
    }
}
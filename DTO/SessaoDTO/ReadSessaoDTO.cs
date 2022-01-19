using System;
using FilmesApi.Entities;

namespace FilmesApi.DTO.SessaoDTO
{
    public class ReadSessaoDTO
    {
        public int Id { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
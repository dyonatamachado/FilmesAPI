using System.Collections.Generic;
using FilmesApi.Entities;

namespace FilmesApi.DTO.GerenteDTO
{
    public class ReadGerenteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Cinema> Cinemas { get; set; }
    }
}
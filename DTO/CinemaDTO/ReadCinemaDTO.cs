using FilmesApi.Entities;

namespace FilmesApi.DTO.CinemaDTO
{
    public class ReadCinemaDTO
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Gerente Gerente { get; private set; }
        public Endereco Endereco { get; private set; }
    }
}
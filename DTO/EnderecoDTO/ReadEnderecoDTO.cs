using FilmesApi.Entities;

namespace FilmesApi.DTO.EnderecoDTO
{
    public class ReadEnderecoDTO
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
    }
}
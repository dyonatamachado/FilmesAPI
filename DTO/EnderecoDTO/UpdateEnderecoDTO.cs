using System.ComponentModel.DataAnnotations;

namespace FilmesApi.DTO.EnderecoDTO
{
    public class UpdateEnderecoDTO
    {
        [Required(ErrorMessage = "O campo Logradouro é obrigatório")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "O campo Bairro é obrigatório")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "O campo Numero é obrigatório")]
        public int Numero { get; set; }
    }
}
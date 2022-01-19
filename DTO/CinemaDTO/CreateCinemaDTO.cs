using System.ComponentModel.DataAnnotations;

namespace FilmesApi.DTO.CinemaDTO
{
    public class CreateCinemaDTO
    {
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }     
        [Required(ErrorMessage = "O campo EnderecoId é obrigatório.")]
        public int EnderecoId { get; set; }
    }
}
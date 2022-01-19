using System.ComponentModel.DataAnnotations;

namespace FilmesApi.DTO.GerenteDTO
{
    public class UpdateGerenteDTO
    {
        [Required(ErrorMessage = "O Campo Nome é obrigatório")]
        public string Nome { get; set; }
    }
}
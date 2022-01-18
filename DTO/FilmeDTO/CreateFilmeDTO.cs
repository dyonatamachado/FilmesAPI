using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using FilmesApi.Services;

namespace FilmesApi.DTO.FilmeDTO
{
    public class CreateFilmeDTO
    {
        public CreateFilmeDTO(CartazService cartazService)
        {
            _cartazService = cartazService;
        }
        private CartazService _cartazService;
        private string _cartazBase64;

        [Required(ErrorMessage = "O campo Título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Diretor é obrigatório")]
        public string Diretor { get; set; }

        [Required(ErrorMessage = "O campo Gênero é obrigatório")]
        public string Genero { get; set; } 

        [Required(ErrorMessage = "O campo Duração é obrigatório")]
        [Range(1,400, ErrorMessage = "A Duração deve variar entre 1 minuto e 400 minutos.")]
        public int Duracao { get; set; }

        [Required(ErrorMessage = "O campo Ano é obrigatório")]
        [Range(1900,2100, ErrorMessage = "O Ano deve variar entre 1900 e 2100.")]
        public int Ano { get; set; }


        [Required(ErrorMessage = "Campo Classificação Etária é obrigatório")]
        public int ClassificacaoEtaria { get; set; }
        

        [Required(ErrorMessage = "O campo CartazBase64 é obrigatório e aceita strings no formato Base64")]
        public string CartazBase64
        {
            get { return _cartazBase64; }
            set { _cartazBase64 = _cartazService.GetBase64StringSemPrefixo(value); }
        }

    }
}
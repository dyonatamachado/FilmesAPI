using System.ComponentModel.DataAnnotations;
using FilmesApi.Services;

namespace FilmesApi.DTO.FilmeDTO
{
    public class UpdateCartazDTO
    {   
        public UpdateCartazDTO(CartazService cartazService)
        {
            _cartazService = cartazService;
        }
        private CartazService _cartazService;
        private string _cartazBase64;
        
        [Required(ErrorMessage = "O campo CartazBase64 é obrigatório.")]
        public string CartazBase64
        {
            get { return _cartazBase64; }
            set 
            { 
                _cartazBase64 = _cartazService.GetBase64StringSemPrefixo(value); 
            }
        }
        
    }
}
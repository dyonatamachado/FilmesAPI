using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using FilmesApi.Services;

namespace FilmesApi.DTO.FilmeDTO
{
    public class UpdateCartazDTO
    { 
        private string _cartazBase64;
        
        [Required(ErrorMessage = "O campo CartazBase64 é obrigatório.")]
        public string CartazBase64
        {
            get { return _cartazBase64; }
            set { _cartazBase64 = new Regex(@"^data:image\/[a-z]+;base64,").Replace(value, "");}
        }
    }
}
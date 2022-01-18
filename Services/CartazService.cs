using System.Text.RegularExpressions;

namespace FilmesApi.Services
{
    public class CartazService
    {
        public string GetBase64StringSemPrefixo(string base64)
        {
            var base64SemPrefixo = new Regex(@"^data:image\/[a-z]+;base64,").Replace(base64, "");
            return base64SemPrefixo;
        }
    }
}
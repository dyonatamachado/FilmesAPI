using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesApi.Entities
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Diretor { get; private set; }
        public string Genero { get; private set; }  
        public int Duracao { get; private set; }
        public int Ano { get; private set; }
        public int ClassificacaoEtaria { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
        [Required]
        public byte[] Cartaz { get; private set; }
    }
}
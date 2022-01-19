using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesApi.Entities
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int GerenteId { get; private set; }
        public int EnderecoId { get; private set; }
        public virtual Gerente Gerente { get; private set; }
        public virtual Endereco Endereco { get; private set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; private set; }
    }
}
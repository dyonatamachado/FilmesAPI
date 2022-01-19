using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesApi.DTO.SessaoDTO
{
    public class CreateSessaoDTO
    {
        [Required(ErrorMessage = "O campo FilmeId é obrigatório")]
        public int FilmeId { get; set; }

        [Required(ErrorMessage = "O campo CinemaId é obrigatório")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "O campo HorarioDeEncerramento é obrigatório")]
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
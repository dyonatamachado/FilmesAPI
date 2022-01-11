namespace FilmesApi.DTO.FilmeDTO
{
    public class ReadFilmeDTO
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Diretor { get; private set; }
        public string Genero { get; private set; }  
        public int Duracao { get; private set; }
        public int Ano { get; private set; }
        public string CartazBase64 { get; private set; }
        public int ClassificacaoEtaria { get; private set; }

    }
}
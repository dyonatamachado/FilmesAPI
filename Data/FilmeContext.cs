using FilmesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base(opt)
        {
            
        }

        public DbSet<Filme> Filmes { get; set; }
    }
}
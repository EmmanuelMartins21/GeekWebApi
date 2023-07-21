using GeekWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekWebApi.Context
{
    public class GeekWebApiContext : DbContext
    {
        public GeekWebApiContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Serie> Series { get; set; }
    }
}
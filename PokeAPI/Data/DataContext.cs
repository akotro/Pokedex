using Microsoft.EntityFrameworkCore;
using PokeAPI.Models;

namespace PokeAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Pokemon>? Pokemon { get; set; }
        public DbSet<Sprites>? Sprites { get; set; }
        public DbSet<Models.Type>? Types { get; set; }
        public DbSet<TypeName>? TypeNames { get; set; }
    }
}

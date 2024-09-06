using Microsoft.EntityFrameworkCore;
using SuperHero2.Entities;

namespace SuperHero2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
                
        }


        public DbSet<Superhero> Superheroes {  get; set; }
    }
}

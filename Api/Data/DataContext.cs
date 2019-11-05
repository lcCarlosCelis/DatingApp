using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {  }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(x => x.Cedula);
        }

        public DbSet<Value> Values { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Foto> Fotos { get; set; }
    }  
}
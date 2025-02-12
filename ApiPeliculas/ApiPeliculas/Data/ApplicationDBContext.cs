using ApiPeliculas.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ApiPeliculas.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        //Aqui pasar todas las entidades (Modelos)
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pelicula> Pelicula { get; set; }
        public DbSet<Usuario> Usuario {  get; set; }
    }
}

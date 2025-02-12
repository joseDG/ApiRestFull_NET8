using Microsoft.EntityFrameworkCore;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
        }

        //Aqui todas las entidades o modelos
        public DbSet<Usuario> Usuarios { get; set; }
    }
}

using DatingApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatingApi.Data
{
    public class DataContext()
    {
        public DbSet<AppUser> Users { get; set; }
    }
}

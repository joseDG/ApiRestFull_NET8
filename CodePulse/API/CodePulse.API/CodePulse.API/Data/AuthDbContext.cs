using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // IDs estáticos para roles
            var readerRoleId = "28d65a5b-a7db-4850-b380-83591f7d7531";
            var writerRoleId = "9740f16c-24a1-4224-a7be-1bb00b7c6892";

            // Definición de roles estáticos
            var roles = new List<IdentityRole>
    {
        new IdentityRole
        {
            Id = readerRoleId,
            Name = "Reader",
            NormalizedName = "READER",  // Normalizado correctamente
            ConcurrencyStamp = readerRoleId  // Valor estático
        },
        new IdentityRole
        {
            Id = writerRoleId,
            Name = "Writer",
            NormalizedName = "WRITER",  // Normalizado correctamente
            ConcurrencyStamp = writerRoleId  // Valor estático
        }
    };

            // Seed de roles
            builder.Entity<IdentityRole>().HasData(roles);

            // ID estático para el usuario Admin
            var adminUserId = "edc267ec-d43c-4e3b-8108-a1a1f819906d";
            var adminEmail = "admin@codepulse.com";
            var adminNormalizedEmail = adminEmail.ToUpper();

            // Crear un usuario administrador
            var admin = new IdentityUser
            {
                Id = adminUserId,
                UserName = adminEmail,
                Email = adminEmail,
                NormalizedEmail = adminNormalizedEmail,
                NormalizedUserName = adminNormalizedEmail,
                EmailConfirmed = true,  // Opcional: confirma el correo por defecto si es necesario
                SecurityStamp = Guid.NewGuid().ToString()  // Valor estático si quieres evitar migraciones continuas
            };

            // Hash de la contraseña
            var passwordHasher = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin@123");

            // Seed del usuario admin
            builder.Entity<IdentityUser>().HasData(admin);

            // Asignar roles al administrador
            var adminRoles = new List<IdentityUserRole<string>>
    {
        new IdentityUserRole<string>
        {
            UserId = adminUserId,
            RoleId = readerRoleId
        },
        new IdentityUserRole<string>
        {
            UserId = adminUserId,
            RoleId = writerRoleId
        }
    };

            // Seed de las asignaciones de roles
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }

    }
}
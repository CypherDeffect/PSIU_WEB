using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PSIU_WEB.Models;

namespace PSIU_WEB.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        { 
        }
        public DbSet<Pacient>? Pacients { get; set; }

        public DbSet<Psycho>? Psychos { get; set; }
    }
}

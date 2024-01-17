using Microsoft.EntityFrameworkCore;

namespace AuthService.Context
{

    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        public DbSet<AuthService.Entities.User> Users { get; set; }
        public DbSet<AuthService.Entities.Scope> Scopes { get; set; }
        public DbSet<Entities.UserScope> UserScopes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.Entity<Entities.Scope>()
            .ToTable("Scope", schema: "Shared");
            modelBuilder.Entity<Entities.User>()
            .ToTable("Users", schema: "Shared");
            modelBuilder.Entity<Entities.UserScope>()
                .ToTable("UserScope", schema: "Shared");
        }
    }
}

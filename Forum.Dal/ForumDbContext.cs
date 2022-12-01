using Forum.Dal.Constants;
using Forum.Dal.EntityConfiguration;
using Forum.Domain;
using Forum.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forum.Dal
{
    public class ForumDbContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options)
        {
            Database.Migrate();
            Database.EnsureCreated();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Theme> Themes { get; set; }

        public void UseIdentityConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users", SchemaConstants.Auth);
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims", SchemaConstants.Auth);
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins", SchemaConstants.Auth);
            modelBuilder.Entity<UserToken>().ToTable("UserTokens", SchemaConstants.Auth);
            modelBuilder.Entity<Role>().ToTable("Roles", SchemaConstants.Auth);
            modelBuilder.Entity<RoleClaim>().ToTable("RoleClaims", SchemaConstants.Auth);
            modelBuilder.Entity<UserRole>().ToTable("UserRole", SchemaConstants.Auth);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
            modelBuilder.ApplyConfiguration(new ThemeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            UseIdentityConfiguration(modelBuilder);
        }

    }
}

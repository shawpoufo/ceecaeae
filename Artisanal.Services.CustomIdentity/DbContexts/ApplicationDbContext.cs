namespace Artisanal.Services.CustomIdentity.DbContexts;

using Artisanal.Services.CustomIdentity.Models.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class ApplicationDbContext : DbContext
{
    public DbSet<LoginDAO> Users { get; set; }
    public DbSet<RoleDAO> Roles { get; set; }
    public ApplicationDbContext(DbContextOptions options):base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.LogTo(Console.WriteLine);
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LoginDAO>()
                .HasOne(p => p.Role)
                .WithMany();
            var adminRole = new RoleDAO{
                Id = 1,
                Label = "admin"
            };
            modelBuilder.Entity<RoleDAO>().HasData(adminRole);
            modelBuilder.Entity<RoleDAO>().HasData(new RoleDAO{
                Id = 2,
                Label = "User"
            });
            
            var hasher = new PwdHash();
            modelBuilder.Entity<LoginDAO>()
            .HasData(new {
                Id = 1,
                UserName = "admin",
                RoleId = 1,
                HashedPassword = hasher.ComputeHash("admin")
            });
            
            
        }
}

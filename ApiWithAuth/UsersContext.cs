using ApiWithAuth.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiWithAuth;

public class UsersContext : IdentityUserContext<AppUser>
{
    
    public UsersContext (DbContextOptions<UsersContext> options)
        : base(options)
    {
        
    }
        
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        
        options.UseNpgsql("Host=localhost;Database=UserBase;Username=postgres;Password=1234;Port=5432");
    }
    public DbSet<AppQuest> AppQuests { get; set; }
    public DbSet<AppPlan> AppPlans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
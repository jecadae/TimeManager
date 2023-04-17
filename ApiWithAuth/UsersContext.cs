using ApiWithAuth.Entity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiWithAuth;

public class UsersContext : IdentityUserContext<AppUser,long>
{
    public UsersContext (DbContextOptions<UsersContext> options)
        : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        
        options.UseNpgsql("Host=localhost;Database=UserBase;Username=postgres;Password=1234;Port=5432");
    }

    public DbSet<AppPlan> AppPlans{ get; set; }
    public DbSet<AppQuest> AppQuests{ get; set; }




}
using ApiWithAuth.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiWithAuth;

public class UsersContext : IdentityUserContext<AppUser,int>
{
    public UsersContext (DbContextOptions<UsersContext> options)
        : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserLogin<int>>().HasNoKey();
        modelBuilder.Entity<IdentityUserToken<int>>().HasNoKey();

        modelBuilder.Entity<AppUserIcon>()
            .HasOne<AppUser>(ic =>ic.AppUser )
            .WithOne(user =>user.AppUserIcon )
            .HasPrincipalKey<AppUserIcon>(icon => icon.AppUserId)
            .HasForeignKey<AppUser>(u => u.AppUserIconsId ).IsRequired(false);
    }

    public DbSet<AppPlan> AppPlans{ get; set; }
    public DbSet<AppQuest> AppQuests{ get; set; }
    public DbSet<AppUserIcon> AppUserIcons{ get; set; }



}
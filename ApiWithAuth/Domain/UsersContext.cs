using ApiWithAuth.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiWithAuth.Domain;

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
        modelBuilder.Entity<IdentityUser<int>>().Ignore(Us => Us.UserName);

        modelBuilder.Entity<AppUserIcon>()
            .HasOne(ic =>ic.AppUser )
            .WithOne(user =>user.AppUserIcon )
            .HasPrincipalKey<AppUserIcon>(icon => icon.AppUserId)
            .HasForeignKey<AppUser>(u => u.AppUserIconsId )
            .IsRequired(false);
        
        modelBuilder.Entity<AppUser>()
            .HasMany(u => u.UserPlans)
            .WithOne(i => i.AppUser)
            .HasForeignKey(o => o.AppUserId)
            .IsRequired(false);

        modelBuilder.Entity<AppPlan>()
            .HasMany(u => u.Quests)
            .WithOne(i => i.AppPlan)
            .HasForeignKey(c => c.AppPlanId)
            .IsRequired(false).OnDelete(DeleteBehavior.Cascade);
    }

    public DbSet<AppPlan> AppPlans{ get; set; }
    public DbSet<AppQuest> AppQuests{ get; set; } 
    public DbSet<AppUserIcon> AppUserIcons{ get; set; }



}
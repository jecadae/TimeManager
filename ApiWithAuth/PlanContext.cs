using ApiWithAuth.Entity;
using Microsoft.EntityFrameworkCore;

namespace ApiWithAuth;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=PlanBase;Username=postgres;Password=1234;Port=5432");
    }
    
    public DbSet<AppPlan> AppPlans { get; set; }
}  
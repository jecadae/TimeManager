namespace WebApplication1.Entity;
using Microsoft.EntityFrameworkCore;
public class UserContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Quest> Quests { get; set; }
    public DbSet<Form> Forms { get; set; }

    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
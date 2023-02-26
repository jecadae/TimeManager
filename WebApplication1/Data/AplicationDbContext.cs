using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Entity;

namespace WebApplication1.Data;

public class AplicationDbContext: IdentityDbContext<User>
{
    public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
    
    {
    }
}
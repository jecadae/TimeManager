using ApiWithAuth.Domain;
using ApiWithAuth.Domain.Models;
using ApiWithAuth.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiWithAuth.Services;

public class PlanService : IPlanService
{
    private readonly UsersContext _context;

    public PlanService(UsersContext usersContext)
    {
        _context = usersContext;
    }

    public async Task<List<AppPlan>> GetAllPlansAsync()
    {
        return await _context.AppPlans.AsNoTracking().Include(x => x.Quests).ToListAsync();
    }

    public async Task<List<AppPlan>> GetAllPlansThisUserAsync(string email )
    {
        var userId = await _context.Users.AsNoTracking().FirstOrDefaultAsync( x => x.Email==email);
        if (userId == null)
            throw new BadHttpRequestException("Такой пользователь не был зарегестрирован",404);
        var x = await _context.AppPlans.AsNoTracking().Include(x => x.Quests).Where(x => x.AppUserId == userId.Id).ToListAsync();
        return x;
    }

    public async Task<AppPlan?> GetPlanByIdAsync(int planId)
    {
        return  await _context.AppPlans.AsNoTracking().Include(x => x.Quests).FirstOrDefaultAsync(x => x.Id == planId);
    }

    public async Task CreatePlanAsync(AppPlan item, string email)
    {
        var userId = await _context.Users.AsNoTracking().FirstOrDefaultAsync( x => x.Email==email);
        if (userId == null)
            throw new BadHttpRequestException("Такой пользователь не был зарегестрирован",404);
        item.AppUserId = userId.Id;
        item.Id = null;
        foreach (var itemQuest in item.Quests)
        {
            itemQuest.Id = null;
        }
        await _context.AppPlans.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task RemovePlanAsync(int planId)
    {
        var result = await _context.AppPlans.Include(x => x.Quests).FirstOrDefaultAsync(x => x.Id == planId);
        _context.AppPlans.Remove(result);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePlanAsync(AppPlan item)
    {
        var result = await _context.AppPlans.Include(x => x.Quests).AsNoTracking().FirstOrDefaultAsync(x => x.Id == item.Id);
        if (result==null)
            throw new BadHttpRequestException("Такой план не был создан",404);
        item.AppUserId = result.AppUserId;
        _context.AppPlans.Update(item);
        await _context.SaveChangesAsync();
    }

}
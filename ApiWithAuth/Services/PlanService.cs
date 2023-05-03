using ApiWithAuth.Domain;
using ApiWithAuth.Entity;
using ApiWithAuth.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiWithAuth.Services;

public class PlanService : IPlanService
{
    private readonly UsersContext _context;

    PlanService(UsersContext usersContext)
    {
        _context = usersContext;
    }

    public async Task<List<AppPlan>> GetAllPlansAsync()
    {
        return await _context.AppPlans.AsNoTracking().Include(x => x.Quests).ToListAsync();
    }

    public async Task<List<AppPlan>> GetAllPlansThisUserAsync(string email )
    {
        var userid = await _context.Users.FirstOrDefaultAsync( x => x.Email==email);
        return await _context.AppPlans.AsNoTracking().Include(x => x.Quests).Where(x => x.AppUserId == userid.Id).ToListAsync();
    }

    public async Task<AppPlan?> GetPlanByIdAsync(int planId)
    {
        return  await _context.AppPlans.AsNoTracking().Include(x => x.Quests).FirstOrDefaultAsync(x => x.Id == planId);
    }

    public async Task CreatePlanAsync(AppPlan item, string email)
    {
        var usid= await _context.Users.FirstOrDefaultAsync(x => x.Email==email);
        item.AppUserId = usid.Id;
        await _context.AppPlans.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task RemovePlanAsync(int planId)
    {
        var result = await _context.AppPlans.Include(x => x.Quests).FirstOrDefaultAsync(x => x.Id == planId);
        _context.Remove<AppPlan>(result);
        await _context.SaveChangesAsync();
    }

    public async Task<AppPlan> UpdatePlanAsync(AppPlan item, int planId)
    {
        var result = await _context.AppPlans.Include(x => x.Quests).FirstOrDefaultAsync(x => x.Id == planId);
        if (result==null)
            throw new BadHttpRequestException("Такой пользователь не был зарегестрирован",404);
        result = item;
        _context.Entry(result).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return (result);
    }








}
using Microsoft.EntityFrameworkCore;
using Promocoes.Context;
using Promocoes.Models;

namespace Promocoes.Repositories.Campaigns;

public class CampaignRepository : ICampaignRepository
{
    private readonly AppDbContext _context;
    public CampaignRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Campaign>> GetAll()
    {
        return await _context.Campaigns.ToListAsync();
    }
    public async Task<Campaign> GetById(Guid id)
    {
        return await _context.Campaigns.Where(c => c.Id == id).FirstOrDefaultAsync();
    }
    public async Task<Campaign> Create(Campaign campaign)
    {
        _context.Campaigns.Add(campaign);
        await _context.SaveChangesAsync();
        return campaign;
    }
    public async Task<Campaign> Update(Campaign campaign)
    {
        _context.Entry(campaign).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return campaign;
    }
    public async Task<Campaign> Delete(Guid id)
    {
        var campaign = await GetById(id);
        _context.Campaigns.Remove(campaign);
        await _context.SaveChangesAsync();
        return campaign;
    }
}
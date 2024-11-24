using Microsoft.EntityFrameworkCore;
using Promocoes.Context;
using Promocoes.Models;

namespace Promocoes.Repositories.Promotions;

public class PromotionRepository : IPromotionRepository
{
    private readonly AppDbContext _context;
    public PromotionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Promotion>> GetAll()
    {
        return await _context.Promotions.Include(c => c.Campaign).ToListAsync();
    }
    public async Task<Promotion> GetById(Guid id)
    {
        return await _context.Promotions.Include(c => c.Campaign).Where(c => c.Id == id).FirstOrDefaultAsync();
    }
    public async Task<Promotion> Create(Promotion promotion)
    {
        _context.Promotions.Add(promotion);
        await _context.SaveChangesAsync();
        return promotion;
    }
    public async Task<Promotion> Update(Promotion promotion)
    {
        _context.Entry(promotion).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return promotion;
    }
    public async Task<Promotion> Delete(Guid id)
    {
        var promotion = await GetById(id);
        _context.Promotions.Remove(promotion);
        await _context.SaveChangesAsync();
        return promotion;
    }
}
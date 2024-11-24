using Microsoft.EntityFrameworkCore;
using Promocoes.Context;
using Promocoes.Models;

namespace Promocoes.Repositories.Coupons;

public class CouponRepository : ICouponRepository
{
    private readonly AppDbContext _context;
    public CouponRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Coupon>> GetAll()
    {
        return await _context.Coupons.Include(c => c.Promotion).ToListAsync();
    }
    public async Task<Coupon> GetById(Guid id)
    {
        return await _context.Coupons.Include(c => c.Promotion).Where(c => c.Id == id).FirstOrDefaultAsync();
    }
    public async Task<Coupon> Create(Coupon coupon)
    {
        _context.Coupons.Add(coupon);
        await _context.SaveChangesAsync();
        return coupon;
    }
    public async Task<Coupon> Update(Coupon coupon)
    {
        _context.Entry(coupon).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return coupon;
    }
    public async Task<Coupon> Delete(Guid id)
    {
        var coupon = await GetById(id);
        _context.Coupons.Remove(coupon);
        await _context.SaveChangesAsync();
        return coupon;
    }
}
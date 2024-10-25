using Promocoes.Models;

namespace Promocoes.Repositories.Coupons;

public interface ICouponRepository
{
    Task<IEnumerable<Coupon>> GetAll();
    Task<Coupon> GetById(Guid id);
    Task<Coupon> Create(Coupon coupon);
    Task<Coupon> Update(Coupon coupon);
    Task<Coupon> Delete(Guid id);
}
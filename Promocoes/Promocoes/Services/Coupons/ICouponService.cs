using Promocoes.Dtos;

namespace Promocoes.Services.Coupons;

public interface ICouponService
{
    Task<IEnumerable<CouponDto>> GetCoupons();
    Task<CouponDto> GetCouponById(Guid id);
    Task AddCoupon(CouponDto couponDto);
    Task UpdateCoupon(CouponDto couponDto);
    Task RemoveCoupon(Guid id);
}

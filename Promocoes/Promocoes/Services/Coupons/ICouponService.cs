using Promocoes.Dtos;
using Promocoes.Request;

namespace Promocoes.Services.Coupons;

public interface ICouponService
{
    Task<IEnumerable<CouponDto>> GetCoupons();
    Task<CouponDto> GetCouponById(Guid id);
    Task AddCoupon(CreateCouponRequest couponDto);
    Task UpdateCoupon(UpdateCouponRequest couponDto);
    Task RemoveCoupon(Guid id);
}

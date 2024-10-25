using AutoMapper;
using Promocoes.Dtos;
using Promocoes.Models;
using Promocoes.Repositories.Coupons;

namespace Promocoes.Services.Coupons;

public class CouponService : ICouponService
{
    private readonly ICouponRepository _CouponRepository;
    private readonly IMapper _mapper;
    public CouponService(ICouponRepository CouponRepository, IMapper mapper)
    {
        _CouponRepository = CouponRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CouponDto>> GetCoupons()
    {
        var couponsEntity = await _CouponRepository.GetAll();
        return _mapper.Map<IEnumerable<CouponDto>>(couponsEntity);
    }
    public async Task<CouponDto> GetCouponById(Guid id)
    {
        var couponEntity = await _CouponRepository.GetById(id);
        return _mapper.Map<CouponDto>(couponEntity);
    }
    public async Task AddCoupon(CouponDto couponDto)
    {
        var couponEntity = _mapper.Map<Coupon>(couponDto);
        await _CouponRepository.Create(couponEntity);
        couponDto.Id = couponEntity.Id;
    }
    public async Task UpdateCoupon(CouponDto couponDto)
    {
        var couponEntity = _mapper.Map<Coupon>(couponDto);
        await _CouponRepository.Update(couponEntity);
    }
    public async Task RemoveCoupon(Guid id)
    {
        var couponEntity = _CouponRepository.GetById(id).Result;
        await _CouponRepository.Delete(couponEntity.Id);
    }
}
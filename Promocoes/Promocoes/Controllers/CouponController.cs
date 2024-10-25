using Microsoft.AspNetCore.Mvc;
using Promocoes.Dtos;
using Promocoes.Services.Coupons;

namespace Promocoes.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CouponController : ControllerBase
{
    private readonly ICouponService _CouponService;

    public CouponController(ICouponService CouponService)
    {
        _CouponService = CouponService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CouponDto>>> Get()
    {
        var couponsDto = await _CouponService.GetCoupons();

        if (couponsDto is null)
            return NotFound("Coupons not found");

        return Ok(couponsDto);
    }

    [HttpGet("{id:Guid}", Name = "GetCoupon")]
    public async Task<ActionResult<CouponDto>> Get(Guid id)
    {
        var couponDto = await _CouponService.GetCouponById(id);
        if (couponDto == null)
        {
            return NotFound("Coupon not found");
        }
        return Ok(couponDto);
    }
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CouponDto couponDto)
    {
        if (couponDto == null)
            return BadRequest("Invalid Data");

        await _CouponService.AddCoupon(couponDto);

        return new CreatedAtRouteResult("GetCoupon", new { id = couponDto.Id },
            couponDto);
    }

    [HttpPut("{id:Guid}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] CouponDto couponDto)
    {
        if (id != couponDto.Id)
            return BadRequest();

        if (couponDto is null)
            return BadRequest();

        await _CouponService.UpdateCoupon(couponDto);

        return Ok(couponDto);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult<CouponDto>> Delete(Guid id)
    {
        var couponDto = await _CouponService.GetCouponById(id);
        if (couponDto == null)
        {
            return NotFound("Coupon not found");
        }

        await _CouponService.RemoveCoupon(id);

        return Ok(couponDto);
    }
}
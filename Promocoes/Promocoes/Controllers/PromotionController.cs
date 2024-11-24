using Microsoft.AspNetCore.Mvc;
using Promocoes.Dtos;
using Promocoes.Request;
using Promocoes.Services.Promotions;

namespace Promocoes.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PromotionController : ControllerBase
{
    private readonly IPromotionService _PromotionService;

    public PromotionController(IPromotionService PromotionService)
    {
        _PromotionService = PromotionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PromotionDto>>> Get()
    {
        var promotionsDto = await _PromotionService.GetPromotions();

        if (promotionsDto is null)
            return NotFound("Promotions not found");

        return Ok(promotionsDto);
    }

    [HttpGet("{id:Guid}", Name = "GetPromotion")]
    public async Task<ActionResult<PromotionDto>> Get(Guid id)
    {
        var promotionDto = await _PromotionService.GetPromotionById(id);
        if (promotionDto == null)
        {
            return NotFound("Promotion not found");
        }
        return Ok(promotionDto);
    }
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreatePromotionRequest promotionDto)
    {
        if (promotionDto == null)
            return BadRequest("Invalid Data");

        await _PromotionService.AddPromotion(promotionDto);

        return new CreatedAtRouteResult("GetPromotion",
            promotionDto);
    }

    [HttpPut("{id:Guid}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] UpdatePromotionRequest promotionDto)
    {
        if (id != promotionDto.Id)
            return BadRequest();

        if (promotionDto is null)
            return BadRequest();

        await _PromotionService.UpdatePromotion(promotionDto);

        return Ok(promotionDto);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult<PromotionDto>> Delete(Guid id)
    {
        var promotionDto = await _PromotionService.GetPromotionById(id);
        if (promotionDto == null)
        {
            return NotFound("Promotion not found");
        }

        await _PromotionService.RemovePromotion(id);

        return Ok(promotionDto);
    }
}
using Microsoft.AspNetCore.Mvc;
using Promocoes.Dtos;
using Promocoes.Services.Campaigns;

namespace Promocoes.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CampaignController : ControllerBase
{
    private readonly ICampaignService _CampaignService;

    public CampaignController(ICampaignService CampaignService)
    {
        _CampaignService = CampaignService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CampaignDto>>> Get()
    {
        var campaignsDto = await _CampaignService.GetCampaigns();

        if (campaignsDto is null)
            return NotFound("Campaigns not found");

        return Ok(campaignsDto);
    }

    [HttpGet("{id:Guid}", Name = "GetCampaign")]
    public async Task<ActionResult<CampaignDto>> Get(Guid id)
    {
        var campaignDto = await _CampaignService.GetCampaignById(id);
        if (campaignDto == null)
        {
            return NotFound("Campaign not found");
        }
        return Ok(campaignDto);
    }
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CampaignDto campaignDto)
    {
        if (campaignDto == null)
            return BadRequest("Invalid Data");

        await _CampaignService.AddCampaign(campaignDto);

        return new CreatedAtRouteResult("GetCampaign", new { id = campaignDto.Id },
            campaignDto);
    }

    [HttpPut("{id:Guid}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] CampaignDto campaignDto)
    {
        if (id != campaignDto.Id)
            return BadRequest();

        if (campaignDto is null)
            return BadRequest();

        await _CampaignService.UpdateCampaign(campaignDto);

        return Ok(campaignDto);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<ActionResult<CampaignDto>> Delete(Guid id)
    {
        var campaignDto = await _CampaignService.GetCampaignById(id);
        if (campaignDto == null)
        {
            return NotFound("Campaign not found");
        }

        await _CampaignService.RemoveCampaign(id);

        return Ok(campaignDto);
    }
}
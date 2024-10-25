using Promocoes.Dtos;

namespace Promocoes.Services.Campaigns;

public interface ICampaignService
{
    Task<IEnumerable<CampaignDto>> GetCampaigns();
    Task<CampaignDto> GetCampaignById(Guid id);
    Task AddCampaign(CampaignDto campaignDto);
    Task UpdateCampaign(CampaignDto campaignDto);
    Task RemoveCampaign(Guid id);
}

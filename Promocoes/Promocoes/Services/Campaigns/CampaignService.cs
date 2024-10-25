using AutoMapper;
using Promocoes.Dtos;
using Promocoes.Models;
using Promocoes.Repositories.Campaigns;

namespace Promocoes.Services.Campaigns;

public class CampaignService : ICampaignService
{
    private readonly ICampaignRepository _CampaignRepository;
    private readonly IMapper _mapper;
    public CampaignService(ICampaignRepository CampaignRepository, IMapper mapper)
    {
        _CampaignRepository = CampaignRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CampaignDto>> GetCampaigns()
    {
        var campaignsEntity = await _CampaignRepository.GetAll();
        return _mapper.Map<IEnumerable<CampaignDto>>(campaignsEntity);
    }
    public async Task<CampaignDto> GetCampaignById(Guid id)
    {
        var campaignEntity = await _CampaignRepository.GetById(id);
        return _mapper.Map<CampaignDto>(campaignEntity);
    }
    public async Task AddCampaign(CampaignDto campaignDto)
    {
        var campaignEntity = _mapper.Map<Campaign>(campaignDto);
        await _CampaignRepository.Create(campaignEntity);
        campaignDto.Id = campaignEntity.Id;
    }
    public async Task UpdateCampaign(CampaignDto campaignDto)
    {
        var campaignEntity = _mapper.Map<Campaign>(campaignDto);
        await _CampaignRepository.Update(campaignEntity);
    }
    public async Task RemoveCampaign(Guid id)
    {
        var campaignEntity = _CampaignRepository.GetById(id).Result;
        await _CampaignRepository.Delete(campaignEntity.Id);
    }
}

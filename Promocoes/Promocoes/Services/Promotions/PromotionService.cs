using AutoMapper;
using Promocoes.Dtos;
using Promocoes.Models;
using Promocoes.Repositories.Promotions;
using Promocoes.Request;

namespace Promocoes.Services.Promotions;

public class PromotionService : IPromotionService
{
    private readonly IPromotionRepository _PromotionRepository;
    private readonly IMapper _mapper;
    public PromotionService(IPromotionRepository PromotionRepository, IMapper mapper)
    {
        _PromotionRepository = PromotionRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PromotionDto>> GetPromotions()
    {
        var promotionsEntity = await _PromotionRepository.GetAll();
        return _mapper.Map<IEnumerable<PromotionDto>>(promotionsEntity);
    }
    public async Task<PromotionDto> GetPromotionById(Guid id)
    {
        var promotionEntity = await _PromotionRepository.GetById(id);
        return _mapper.Map<PromotionDto>(promotionEntity);
    }
    public async Task AddPromotion(CreatePromotionRequest promotionDto)
    {
        var promotionEntity = _mapper.Map<Promotion>(promotionDto);
        await _PromotionRepository.Create(promotionEntity);
    }
    public async Task UpdatePromotion(UpdatePromotionRequest promotionDto)
    {
        var promotionEntity = _mapper.Map<Promotion>(promotionDto);
        await _PromotionRepository.Update(promotionEntity);
    }
    public async Task RemovePromotion(Guid id)
    {
        var promotionEntity = _PromotionRepository.GetById(id).Result;
        await _PromotionRepository.Delete(promotionEntity.Id);
    }
}
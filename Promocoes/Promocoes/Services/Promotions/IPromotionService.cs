using Promocoes.Dtos;
using Promocoes.Request;

namespace Promocoes.Services.Promotions;

public interface IPromotionService
{
    Task<IEnumerable<PromotionDto>> GetPromotions();
    Task<PromotionDto> GetPromotionById(Guid id);
    Task AddPromotion(CreatePromotionRequest promotionDto);
    Task UpdatePromotion(UpdatePromotionRequest promotionDto);
    Task RemovePromotion(Guid id);
}
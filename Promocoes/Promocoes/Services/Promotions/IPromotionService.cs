using Promocoes.Dtos;

namespace Promocoes.Services.Promotions;

public interface IPromotionService
{
    Task<IEnumerable<PromotionDto>> GetPromotions();
    Task<PromotionDto> GetPromotionById(Guid id);
    Task AddPromotion(PromotionDto promotionDto);
    Task UpdatePromotion(PromotionDto promotionDto);
    Task RemovePromotion(Guid id);
}
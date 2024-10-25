using Promocoes.Models;

namespace Promocoes.Repositories.Promotions;

public interface IPromotionRepository
{
    Task<IEnumerable<Promotion>> GetAll();
    Task<Promotion> GetById(Guid id);
    Task<Promotion> Create(Promotion promotion);
    Task<Promotion> Update(Promotion promotion);
    Task<Promotion> Delete(Guid id);
}
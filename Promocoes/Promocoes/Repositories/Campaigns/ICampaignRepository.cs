using Promocoes.Models;

namespace Promocoes.Repositories.Campaigns;

public interface ICampaignRepository
{
    Task<IEnumerable<Campaign>> GetAll();
    Task<Campaign> GetById(Guid id);
    Task<Campaign> Create(Campaign campaign);
    Task<Campaign> Update(Campaign campaign);
    Task<Campaign> Delete(Guid id);
}
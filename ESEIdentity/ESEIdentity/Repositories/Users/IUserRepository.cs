using ESEIdentity.Models;

namespace ESEIdentity.Repositories.Users;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();
    Task<User> GetById(Guid id);
    Task<User> Create(User user);
    Task<User> Update(User user);
    Task<User> Delete(Guid id);
    Task<User> GetByUserAndPassword(AuthenticationRequest request);
}
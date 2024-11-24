using ESEIdentity.Dtos;
using ESEIdentity.Models;

namespace ESEIdentity.Services.Users;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetUsers();
    Task<UserDto> GetUserById(Guid id);
    Task<UserDto> GetUserByNameAndPassWord(AuthenticationRequest request);
    Task AddUser(UserDto userDto);
    Task UpdateUser(UserDto userDto);
    Task RemoveUser(Guid id);
}

using ESEIdentity.Dtos;

namespace ESEIdentity.Services.Users;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetUsers();
    Task<UserDto> GetUserById(Guid id);
    Task AddUser(UserDto userDto);
    Task UpdateUser(UserDto userDto);
    Task RemoveUser(Guid id);
}

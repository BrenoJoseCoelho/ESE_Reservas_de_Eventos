using AutoMapper;
using ESEIdentity.Dtos;
using ESEIdentity.Models;
using ESEIdentity.Repositories.Users;

namespace ESEIdentity.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetUsers()
    {
        var usersEntity = await _userRepository.GetAll();
        return _mapper.Map<IEnumerable<UserDto>>(usersEntity);
    }
    public async Task<UserDto> GetUserById(Guid id)
    {
        var userEntity = await _userRepository.GetById(id);
        return _mapper.Map<UserDto>(userEntity);
    }
    public async Task AddUser(UserDto userDto)
    {
        var userEntity = _mapper.Map<User>(userDto);
        await _userRepository.Create(userEntity);
        userDto.Id = userEntity.Id;
    }
    public async Task UpdateUser(UserDto userDto)
    {
        var userEntity = _mapper.Map<User>(userDto);
        await _userRepository.Update(userEntity);
    }
    public async Task RemoveUser(Guid id)
    {
        var userEntity = _userRepository.GetById(id).Result;
        await _userRepository.Delete(userEntity.Id);
    }
}
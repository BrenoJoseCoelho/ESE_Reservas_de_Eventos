using ESEIdentity.Context;
using ESEIdentity.Models;
using Microsoft.EntityFrameworkCore;

namespace ESEIdentity.Repositories.Users;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }
    public async Task<User> GetById(Guid id)
    {
        return await _context.Users.Where(c => c.Id == id).FirstOrDefaultAsync();
    }
    public async Task<User> GetByUserAndPassword(AuthenticationRequest request)
    {
        return await _context.Users.Where(c => c.Name == request.UserName && c.Password == request.Password).FirstOrDefaultAsync();
    }
    public async Task<User> Create(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }
    public async Task<User> Update(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return user;
    }
    public async Task<User> Delete(Guid id)
    {
        var user = await GetById(id);
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }
}
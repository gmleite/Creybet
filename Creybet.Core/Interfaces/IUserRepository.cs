using Creybet.Core.Models;

namespace Creybet.Core.Interfaces;

public interface IUserRepository
{
    Task<IReadOnlyList<User>> GetAllAsync();
    Task<User> GetByIdAsync(string id);
    Task<int> AddAsync(User entity);
    Task<int> UpdateAsync(User entity);
    Task<int> DeleteAsync(string id);
    Task UpdateBalanceAsync(string id, decimal amount);
}


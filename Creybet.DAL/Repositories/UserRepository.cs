using System.Data;
using Creybet.Core.Interfaces;
using Creybet.Core.Models;
using Creybet.DAL.Queries;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Creybet.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IConfiguration _config;
    public UserRepository(IConfiguration config)
    {
        _config = config;
    }

    public async Task<int> AddAsync(User entity)
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("AzureSQL")))
        {
            var result = await connection.ExecuteAsync(UserQueries.AddUser, new { entity.Name, entity.DiscordUserId, entity.Balance, entity.BetsLost, entity.BetsWon, entity.DidDailyCheckin });
            return result;
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("AzureSQL")))
        {
            var result = await connection.ExecuteAsync(UserQueries.DeleteUser, new { Id = id });
            return result;
        }
    }

    public async Task<IReadOnlyList<User>> GetAllAsync()
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("AzureSQL")))
        {
            var users = await connection.QueryAsync<User>(UserQueries.GetUsers);
            return users.ToList();
        }
    }

    public async Task<User> GetByIdAsync(long id)
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("AzureSQL")))
        {
            var user = await connection.QuerySingleOrDefaultAsync<User>(UserQueries.GetUserById, new { Id = id });
            return user;
        }
    }

    public async Task<int> UpdateAsync(User entity)
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("AzureSQL")))
        {
            var user = await connection.ExecuteAsync(UserQueries.UpdateUser, new { entity.DiscordUserId, entity.Name, entity.Balance, entity.BetsLost, entity.BetsWon, entity.DidDailyCheckin });
            return user;
        }
    }
}
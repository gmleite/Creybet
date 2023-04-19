using System.Data;
using Creybet.Core.Interfaces;
using Creybet.Core.Models;
using Creybet.DAL.Queries;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Creybet.DAL.Repositories;

public class BetRepository : IBetRepository
{
    private readonly IConfiguration _config;
    public BetRepository(IConfiguration config)
    {
        _config = config;
    }

    public async Task<int> AddAsync(Bet entity)
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
        {
            var result = await connection.ExecuteAsync(BetQueries.AddBet, new { entity.BetResult, entity.BetValue, entity.ChoosenOption, entity.CreatedAt, entity.BetId, entity.UserId, entity.GameId});
            return result;
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
        {
            var result = await connection.ExecuteAsync(BetQueries.DeleteBet, new { Id = id });
            return result;
        }
    }

    public async Task<IReadOnlyList<Bet>> GetAllAsync()
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
        {
            var Bets = await connection.QueryAsync<Bet>(BetQueries.GetBets);
            return Bets.ToList();
        }
    }

    public async Task<Bet> GetByIdAsync(long id)
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
        {
            var bet = await connection.QuerySingleOrDefaultAsync<Bet>(BetQueries.GetBetById, new { Id = id });
            return bet;
        }
    }

    public async Task<int> UpdateAsync(Bet entity)
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
        {
            var bet = await connection.ExecuteAsync(BetQueries.UpdateBet, new { entity.BetId, entity.BetResult, entity.BetValue, entity.ChoosenOption, entity.CreatedAt, entity.GameId, entity.UserId });
            return bet;
        }
    }
}
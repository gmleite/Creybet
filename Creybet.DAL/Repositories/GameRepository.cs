using System.Data;
using Creybet.Core.Interfaces;
using Creybet.Core.Models;
using Creybet.DAL.Queries;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Creybet.DAL.Repositories;

public class GameRepository : IGameRepository
{
    private readonly IConfiguration _config;
    public GameRepository(IConfiguration config)
    {
        _config = config;
    }

    public async Task<int> AddAsync(Game entity)
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
        {
            var result = await connection.ExecuteAsync(GameQueries.AddGame, new { entity.CreatedBy, entity.VictoryPayout, entity.DefeatPayout, entity.TotalVictoryBalance, entity.TotalDefeatBalance, entity.CreatedAt, entity.GameResult });
            return result;
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
        {
            var result = await connection.ExecuteAsync(GameQueries.DeleteGame, new { Id = id });
            return result;
        }
    }

    public async Task<IReadOnlyList<Game>> GetAllAsync()
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
        {
            var games = await connection.QueryAsync<Game>(GameQueries.GetGames);
            return games.ToList();
        }
    }

    public async Task<Game> GetByIdAsync(long id)
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
        {
            var game = await connection.QuerySingleOrDefaultAsync<Game>(GameQueries.GetGameById, new { Id = id });
            return game;
        }
    }

    public async Task<int> UpdateAsync(Game entity)
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
        {
            var game = await connection.ExecuteAsync(GameQueries.UpdateGame, new { entity.GameId, entity.CreatedBy, entity.VictoryPayout, entity.DefeatPayout, entity.TotalVictoryBalance, entity.TotalDefeatBalance, entity.CreatedAt, entity.GameResult });
            return game;
        }
    }
}
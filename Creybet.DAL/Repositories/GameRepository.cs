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
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("AzureSQL")))
        {
            var result = await connection.ExecuteAsync(GameQueries.AddGame, new { entity.CreatedBy, entity.VictoryPayout, entity.DefeatPayout, entity.TotalVictoryBalance, entity.TotalDefeatBalance, entity.CreatedAt, entity.GameResult });
            return result;
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("AzureSQL")))
        {
            var result = await connection.ExecuteAsync(GameQueries.DeleteGame, new { Id = id });
            return result;
        }
    }

    public async Task<IReadOnlyList<Game>> GetAllAsync()
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("AzureSQL")))
        {
            var games = await connection.QueryAsync<Game>(GameQueries.GetGames);
            return games.ToList();
        }
    }

    public async Task<Game> GetByIdAsync(long id)
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("AzureSQL")))
        {
            var game = await connection.QuerySingleOrDefaultAsync<Game>(GameQueries.GetGameById, new { Id = id });
            return game;
        }
    }

    public async Task<IEnumerable<Game>> GetGamesAvailableToBetAsync()
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("AzureSQL")))
        {
            var game = await connection.QueryAsync<Game>(GameQueries.FindGameAvailableToBet);
            return game;
        }
    }

    public async Task<IEnumerable<Game>> GetGamesByUserAsync(string discordUserId)
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("AzureSQL")))
        {
            var game = await connection.QueryAsync<Game>(GameQueries.FindGameByUser, new { discordUserId });
            return game;
        }
    }

    public async Task<int> UpdateAsync(Game entity)
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("AzureSQL")))
        {
            var game = await connection.ExecuteAsync(GameQueries.UpdateGame, new { entity.GameId, entity.CreatedBy, entity.VictoryPayout, entity.DefeatPayout, entity.TotalVictoryBalance, entity.TotalDefeatBalance, entity.CreatedAt, entity.GameResult });
            return game;
        }
    }

    public async Task<int> UpdatePayout(int gameId, decimal victoryPayout, decimal defeatPayout, decimal totalVictoryBalance, decimal totalDefeatBalance)
    {
        using (IDbConnection connection = new SqlConnection(_config.GetConnectionString("AzureSQL")))
        {
            var game = await connection.ExecuteAsync(GameQueries.UpdatePayout, new { gameId, victoryPayout, defeatPayout, totalVictoryBalance, totalDefeatBalance });
            return game;
        }
    }

    public Game CalculateVictoryPayout(Game game, decimal betValue)
    {
        game.TotalVictoryBalance += betValue;
        game.VictoryPayout = (game.TotalDefeatBalance + game.TotalVictoryBalance) / game.TotalVictoryBalance;
        game.DefeatPayout = (game.TotalDefeatBalance + game.TotalVictoryBalance) / game.TotalDefeatBalance;

        if (game.VictoryPayout < 1.10m)
        {
            game.VictoryPayout = 1.10m;
        }
        return game;
    }

    public Game CalculateDefeatPayout(Game game, decimal betValue)
    {
        game.TotalDefeatBalance += betValue;
        game.DefeatPayout = (game.TotalDefeatBalance + game.TotalVictoryBalance) / game.TotalDefeatBalance;
        game.VictoryPayout = (game.TotalDefeatBalance + game.TotalVictoryBalance) / game.TotalVictoryBalance;
        if (game.DefeatPayout < 1.10m)
        {
            game.DefeatPayout = 1.10m;
        }
        return game;
    }
}
using Creybet.Core.Models;

namespace Creybet.Core.Interfaces;

public interface IGameRepository : IRepository<Game>
{
    Task<IEnumerable<Game>> GetGamesByUserAsync(string discordUserId);
    Task<IEnumerable<Game>> GetGamesAvailableToBetAsync();
    Task<int> UpdatePayout(int gameId, decimal victoryPayout, decimal defeatPayout, decimal totalVictoryBalance, decimal totalDefeatBalance);
    Game CalculateVictoryPayout(Game game, decimal betValue);
    Game CalculateDefeatPayout(Game game, decimal betValue);
}


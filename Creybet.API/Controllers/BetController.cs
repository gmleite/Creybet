using Creybet.Core.DTOs;
using Creybet.Core.Interfaces;
using Creybet.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Creybet.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BetController : ControllerBase
{
    private readonly IBetRepository _betRepository;
    private readonly IGameRepository _gameRepository;
    public BetController(IBetRepository betRepository, IGameRepository gameRepository)
    {
        _betRepository = betRepository;
        _gameRepository = gameRepository;
    }

    [HttpGet("FindAll")]
    public IEnumerable<Bet> FindAll()
    {
        return _betRepository.GetAllAsync().Result;
    }

    [HttpGet("FindOne/{id}")]
    public Bet FindOne(int id)
    {
        return _betRepository.GetByIdAsync(id).Result;
    }

    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateBetDTO Bet)
    {
        Game game = _gameRepository.GetByIdAsync(Bet.GameId).Result;
        decimal betvalue = Bet.BetValue;
        if (game == null)
        {
            return BadRequest();
        }
        if (Bet.ChoosenOption)
        {
            if (game.TotalVictoryBalance == 1)
            {
                betvalue = Bet.BetValue - 1;
            }
            game = _gameRepository.CalculateVictoryPayout(game, betvalue);
        }
        else
        {
            if (game.TotalDefeatBalance == 1)
            {
                betvalue = Bet.BetValue - 1;
            }
            game = _gameRepository.CalculateDefeatPayout(game, betvalue);

        }

        var rowsAffectedBet = _betRepository.AddAsync(new Bet
        {
            DiscordUserId = Bet.DiscordUserId,
            GameId = Bet.GameId,
            ChoosenOption = Bet.ChoosenOption,
            BetValue = Bet.BetValue,
            CreatedAt = DateTime.Now,
            BetResult = null
        }).Result;

        var rowsAffectedGame = _gameRepository.UpdatePayout(Bet.GameId, game.VictoryPayout, game.DefeatPayout, game.TotalVictoryBalance, game.TotalDefeatBalance).Result;

        if (rowsAffectedBet > 0)
        {
            return Created("Bet", new Dictionary<string, decimal> { { "VictoryPayout", game.VictoryPayout }, {"DefeatPayout", game.DefeatPayout} });
        }
        return BadRequest();
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] Bet Bet)
    {
        int rowsAffected = _betRepository.UpdateAsync(Bet).Result;
        if (rowsAffected > 0)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpDelete("Delete/{id}")]
    public IActionResult Delete(int id)
    {
        int rowsAffected = _betRepository.DeleteAsync(id).Result;
        if (rowsAffected > 0)
        {
            return Ok();
        }
        return BadRequest();
    }
}
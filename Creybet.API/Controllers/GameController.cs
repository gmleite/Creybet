using Creybet.Core.DTOs;
using Creybet.Core.Interfaces;
using Creybet.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Creybet.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameRepository _gameRepository;
    public GameController(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    [HttpGet("FindAll")]
    public IEnumerable<Game> FindAll()
    {
        return _gameRepository.GetAllAsync().Result;
    }

    [HttpGet("FindOne/{id}")]
    public Game FindOne(int id)
    {
        return _gameRepository.GetByIdAsync(id).Result;
    }

    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateGameDTO game)
    {
        var rowsAffected = _gameRepository.AddAsync(new Game
        {
            CreatedBy = game.CreatedBy,
            VictoryPayout = 1.5m,
            DefeatPayout = 1.5m,
            TotalVictoryBalance = 1.0m,
            TotalDefeatBalance = 1.0m,
            CreatedAt = DateTime.Now,
            GameResult = null
        }).Result;

        if (rowsAffected > 0)
        {
            return Created("Game", new Dictionary<string, bool> { { "success", true } });
        }
        return BadRequest();
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] Game Game)
    {
        int rowsAffected = _gameRepository.UpdateAsync(Game).Result;
        if (rowsAffected > 0)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpDelete("Delete/{id}")]
    public IActionResult Delete(int id)
    {
        int rowsAffected = _gameRepository.DeleteAsync(id).Result;
        if (rowsAffected > 0)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpGet("FindGameByUser/{discordUserId}")]
    public IEnumerable<Game> FindGameByUser(string discordUserId)
    {
        return _gameRepository.GetGamesByUserAsync(discordUserId).Result;
    }

    [HttpGet("FindGameAvailableToBet")]
    public IEnumerable<Game> FindGameAvailableToBet()
    {
        return _gameRepository.GetGamesAvailableToBetAsync().Result;
    }
}
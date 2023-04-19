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
    public BetController(IBetRepository betRepository)
    {
        _betRepository = betRepository;
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
        var rowsAffected = _betRepository.AddAsync(new Bet
        {
            UserId = Bet.UserId,
            GameId = Bet.GameId,
            ChoosenOption = Bet.ChoosenOption,
            BetValue = Bet.BetValue,
            CreatedAt = DateTime.Now,
            BetResult = null
        }).Result;

        if (rowsAffected > 0)
        {
            return Created("Bet", new Dictionary<string, bool> { { "success", true } });
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
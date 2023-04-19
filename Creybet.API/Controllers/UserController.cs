using Creybet.Core.DTOs;
using Creybet.Core.Models;
using Creybet.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Creybet.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("FindAll")]
    public IEnumerable<User> FindAll()
    {
        return _userRepository.GetAllAsync().Result;
    }

    [HttpGet("FindOne/{id}")]
    public User FindOne(int id)
    {
        return _userRepository.GetByIdAsync(id).Result;
    }

    [HttpPost("Create")]
    public IActionResult Create([FromBody] CreateUserDTO user)
    {
        var rowsAffected = _userRepository.AddAsync(new User
        {
            Balance = user.Balance,
            Name = user.Name,
            DiscordUserId = user.DiscordUserId,
            DidDailyCheckin = user.DidDailyCheckin,
            BetsWon = user.BetsWon,
            BetsLost = user.BetsLost
        }).Result;

        if (rowsAffected > 0)
        {
            return Created("User", user);
        }
        return BadRequest();
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] User user)
    {
        int rowsAffected = _userRepository.UpdateAsync(user).Result;
        if (rowsAffected > 0)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpDelete("Delete/{id}")]
    public IActionResult Delete(int id)
    {
        int rowsAffected = _userRepository.DeleteAsync(id).Result;
        if (rowsAffected > 0)
        {
            return Ok();
        }
        return BadRequest();
    }
}
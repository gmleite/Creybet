using System.ComponentModel.DataAnnotations.Schema;

namespace Creybet.Core.Models;

public class Game
{
    public int GameId { get; set; }
    public string CreatedBy { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal VictoryPayout { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal DefeatPayout { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalVictoryBalance { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalDefeatBalance { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? GameResult { get; set; }

    public Game()
    {
        if (CreatedBy == null)
        {
            CreatedBy = "";
        }
    }
}
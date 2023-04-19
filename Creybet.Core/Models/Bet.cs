using System.ComponentModel.DataAnnotations.Schema;
namespace Creybet.Core.Models;

public class Bet
{
    public int BetId { get; set; }
    public int UserId { get; set; }
    public int GameId { get; set; }
    public bool ChoosenOption { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal BetValue { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool? BetResult { get; set; }

}
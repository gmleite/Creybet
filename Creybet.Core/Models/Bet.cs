using System.ComponentModel.DataAnnotations.Schema;
namespace Creybet.Core.Models;

public class Bet
{
    public int BetId { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User? User { get; set; }
    [ForeignKey(nameof(Game))]
    public int GameId { get; set; }
    public Game? Game { get; set; }
    public bool ChoosenOption { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal BetValue { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool? BetResult { get; set; }

}
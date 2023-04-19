namespace Creybet.Core.DTOs;


public partial class CreateBetDTO
{
    public int UserId { get; set; }
    public int GameId { get; set; }
    public bool ChoosenOption { get; set; }
    public decimal BetValue { get; set; }
}
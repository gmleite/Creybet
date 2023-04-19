namespace Creybet.Core.DTOs;


public partial class CreateBetDTO
{
    public string DiscordUserId { get; set; }
    public int GameId { get; set; }
    public bool ChoosenOption { get; set; }
    public decimal BetValue { get; set; }

    public CreateBetDTO()
    {
        if (DiscordUserId == null)
        {
            DiscordUserId = "";
        }
    }
}
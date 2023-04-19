namespace Creybet.Core.DTOs;


public partial class CreateUserDTO
{
    public string Name { get; set; }
    public string DiscordUserId { get; set; }
    public decimal Balance { get; set; }
    public bool DidDailyCheckin { get; set; }
    public int BetsWon { get; set; }
    public int BetsLost { get; set; }

    public CreateUserDTO()
    {
        if (Name == null)
        {
            Name = "";
        }
        if (DiscordUserId == null)
        {
            DiscordUserId = "";
        }
    }
}
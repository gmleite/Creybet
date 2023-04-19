namespace Creybet.Core.DTOs;


public partial class CreateUserDTO
{
    public string DiscordUserId { get; set; }
    public decimal Balance { get; set; }
    public bool DidDailyCheckin { get; set; }
    public int BetsWon { get; set; }
    public int BetsLost { get; set; }

    public CreateUserDTO()
    {
        if(DiscordUserId == null){
            DiscordUserId = "";
        }
    }
}
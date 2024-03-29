namespace Creybet.Core.Models;


public partial class User
{
    public string DiscordUserId { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public bool DidDailyCheckin { get; set; }
    public int BetsWon { get; set; }
    public int BetsLost { get; set; }

    public User()
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
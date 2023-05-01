namespace Creybet.DAL.Queries;

public class UserQueries
{
    public static string GetUsers = @"SELECT * FROM CreybetSchema.Users";
    public static string GetUserById = @"SELECT * FROM CreybetSchema.Users WHERE DiscordUserId = @Id";
    public static string AddUser = @"INSERT INTO CreybetSchema.Users (DiscordUserId, Name,  Balance, BetsLost, BetsWon, DidDailyCheckin) VALUES (@DiscordUserId, @Name, @Balance, @BetsLost, @BetsWon, @DidDailyCheckin)";
    public static string UpdateUser = @"UPDATE CreybetSchema.Users SET Name = @Name, Balance = @Balance, BetsLost = @BetsLost, BetsWon = @BetsWon, DidDailyCheckin = @DidDailyCheckin WHERE DiscordUserId = @DiscordUserId";
    public static string DeleteUser = @"DELETE FROM CreybetSchema.Users WHERE DiscordUserId = @Id";
    public static string UpdateUserBalance = @"UPDATE CreybetSchema.Users SET Balance = @Balance WHERE DiscordUserId = @DiscordUserId";
}
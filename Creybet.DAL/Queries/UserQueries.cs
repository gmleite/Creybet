namespace Creybet.DAL.Queries;

public class UserQueries
{
    public static string GetUsers = @"SELECT * FROM CreybetSchema.Users";
    public static string GetUserById = @"SELECT * FROM CreybetSchema.Users WHERE UserId = @Id";
    public static string AddUser = @"INSERT INTO CreybetSchema.Users (DiscordUserId, Balance, BetsLost, BetsWon, DidDailyCheckin) VALUES (@DiscordUserId, @Balance, @BetsLost, @BetsWon, @DidDailyCheckin)";
    public static string UpdateUser = @"UPDATE CreybetSchema.Users SET DiscordUserId = @DiscordUserId, Balance = @Balance, BetsLost = @BetsLost, BetsWon = @BetsWon, DidDailyCheckin = @DidDailyCheckin WHERE UserId = @UserId";
    public static string DeleteUser = @"DELETE FROM CreybetSchema.Users WHERE UserId = @Id";
}
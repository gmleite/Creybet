namespace Creybet.DAL.Queries;

public class GameQueries
{
    public static string GetGames = @"SELECT * FROM CreybetSchema.Games";
    public static string GetGameById = @"SELECT * FROM CreybetSchema.Games WHERE GameId = @Id";
    public static string AddGame = @"INSERT INTO CreybetSchema.Games (CreatedBy, VictoryPayout, DefeatPayout, TotalVictoryBalance, TotalDefeatBalance, CreatedAt, GameResult) VALUES (@CreatedBy, 1.5, 1.5, 1.0, 1.0, @CreatedAt, @GameResult);";
    public static string UpdateGame = @"UPDATE CreybetSchema.Games SET CreatedBy = @CreatedBy, VictoryPayout = @VictoryPayout, DefeatPayout = @DefeatPayout, TotalVictoryBalance = @TotalVictoryBalance, TotalDefeatBalance = @TotalDefeatBalance, CreatedAt = @CreatedAt, GameResult = @GameResult WHERE GameId = @GameId;";
    public static string DeleteGame = @"DELETE FROM CreybetSchema.Games WHERE GameId = @Id;";
}

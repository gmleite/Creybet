namespace Creybet.DAL.Queries;

public class BetQueries
{
    public static string GetBets = @"SELECT * FROM CreybetSchema.Bets";
    public static string GetBetById = @"SELECT * FROM CreybetSchema.Bets WHERE BetId = @Id";
    public static string AddBet = @"INSERT INTO CreybetSchema.Bets (UserId, GameId, ChoosenOption, BetValue, CreatedAt, BetResult) VALUES (@UserId, @GameId, @ChoosenOption, @BetValue, @CreatedAt, @BetResult)";
    public static string UpdateBet = @"UPDATE CreybetSchema.Bets SET GameId = @GameId, ChoosenOption = @ChoosenOption, BetValue = @BetValue, CreatedAt = @CreatedAt, BetResult = @BetResult WHERE BetId = @BetId";
    public static string DeleteBet = @"DELETE FROM CreybetSchema.Bets WHERE BetId = @Id;";
}

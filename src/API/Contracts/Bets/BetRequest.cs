namespace api.Contracts.Bets;

public record BetRequest(string PlayerName, int BetAmount, int BetNumber);
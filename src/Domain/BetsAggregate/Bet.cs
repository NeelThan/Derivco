using Domain.Common;

namespace Domain.BetsAggregate;

public class Bet: Entity
{
    private Bet(Guid? newGuid, string playerName, int betAmount, int betNumber)
    {
        Id = newGuid ?? Guid.NewGuid();
        PlayerName = playerName;
        BetAmount = betAmount;
        BetNumber = betNumber;
    }

    public Guid Id { get; set; }
    public string PlayerName { get; set; }
    public int BetAmount { get; set; }
    public int BetNumber { get; set; }
    public DateTime CreatedAt { get; set; } = new(); //move to implementation
    
    public static Bet Create(Guid id, string playerName, int betAmount, int betNumber) 
        => new(id, playerName, betAmount, betNumber);
    
    public static Bet CreateUnique(string playerName, int betAmount, int betNumber)
        => new(Guid.NewGuid(),
                playerName,
                betAmount,
                betNumber);
    
    //other business logic
}
using Domain.BetsAggregate;
using Shouldly;

namespace Domain.UnitTests;

public class BetTests
{
    [Fact]
    public void CreateUnique_ShouldCreateBetWithUniqueGuid()
    {
        // Arrange
        var playerName = "John";
        var betAmount = 100;
        var betNumber = 5;

        // Act
        Bet bet = Bet.CreateUnique(playerName, betAmount, betNumber);

        // Assert
        bet.Id.ShouldNotBe(Guid.Empty);
        bet.PlayerName.ShouldBe(playerName);
        bet.BetAmount.ShouldBe(betAmount);
        bet.BetNumber.ShouldBe(betNumber);
    }
}
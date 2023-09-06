using Application.ManageBets;
using Domain.BetsAggregate;
using NSubstitute;
using Shouldly;

namespace Application.UnitTests;

public class BetCommandHandlerTests
{
    [Fact]
    public async Task GivenValidBetCommand_ShouldReturnBet()
    {
        // Arrange
        var betRepository = Substitute.For<IBetRepository>();
        var command = new BetCommand("John", 100, 0);
        var sut = new BetCommandHandler(betRepository);
        
        // Act
        var result = await sut.Handle(command, CancellationToken.None);
        
        // Assert
        result.IsError.ShouldBeFalse();
        var bet = await betRepository.GetBetByIdAsync(result.Value);
        command.PlayerName.ShouldBe(bet.PlayerName);
        command.BetAmount.ShouldBe(bet.BetAmount);
        command.BetNumber.ShouldBe(bet.BetNumber);
    }
}
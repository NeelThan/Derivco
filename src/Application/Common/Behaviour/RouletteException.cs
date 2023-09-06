namespace Application.Common.Behaviour;

public class RouletteException : Exception
{
    public RouletteException(string message) : base(message) { }

    public RouletteException(string message, Exception innerException)
            : base(message,
                    innerException) { }
}
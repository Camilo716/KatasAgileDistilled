namespace Katas.ObjectCalisthenics.TicTacToe.V1.Exceptions;

public class PlayOnPlayedPositionException : Exception
{
    public PlayOnPlayedPositionException()
    {
    }

    public PlayOnPlayedPositionException(string? message) : base(message)
    {
    }
}
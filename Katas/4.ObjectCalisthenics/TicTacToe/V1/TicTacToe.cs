


namespace Katas.ObjectCalisthenics.TicTacToe.V1;

public class TicTacToe
{
    public char[,] Board { get; private set; }
    private int _nextToPlayId;

    public TicTacToe()
    {
        Board = GenerateEmptyBoard();
        _nextToPlayId = 1;
    }

    public void PlaceMark(Coords coords)
    {
        char mark = _nextToPlayId == 1 ? 'X' : 'O';

        Board[coords.Y, coords.X] = mark;

        UpdateNextPlayerToPlay();
    }


    private static char[,] GenerateEmptyBoard()
    {
        return new char[3,3] {
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {' ', ' ', ' '},
        };
    }

    private void UpdateNextPlayerToPlay()
    {
        _nextToPlayId = _nextToPlayId == 1 ? 2 : 1;
    }
}
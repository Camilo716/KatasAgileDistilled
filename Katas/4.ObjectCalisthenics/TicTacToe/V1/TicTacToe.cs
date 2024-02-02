


using Katas.ObjectCalisthenics.TicTacToe.V1.Exceptions;

namespace Katas.ObjectCalisthenics.TicTacToe.V1;

public class TicTacToe
{
    public char[,] Board { get; private set; }
    private int _nextToPlayId;
    public int WinnerId { get; private set; } = -1;  

    public TicTacToe()
    {
        Board = GenerateEmptyBoard();
        _nextToPlayId = 1;
    }

    public void PlaceMark(Coords coords)
    {
        bool isEmptyPosition = Board[coords.Y, coords.X].Equals(' '); 
        if(!isEmptyPosition)
            throw new PlayOnPlayedPositionException($"The position Y: {coords.Y} X: {coords.X} is not empty");

        char mark = _nextToPlayId == 1 ? 'X' : 'O';
        Board[coords.Y, coords.X] = mark;

        CheckForWinner(mark, _nextToPlayId);
        UpdateNextPlayerToPlay();
    }

    private void CheckForWinner(char mark, int playerId)
    {
        CheckForHorizontalWin(mark, playerId);
        CheckForVerticalWin(mark, playerId);
        CheckForDiagonalWin(mark, playerId);
    }


    private void CheckForHorizontalWin(char mark, int playerId)
    {
        for(int row = 0; row < 3; row++)
        {
            bool markIsInFullRow = Board[row, 0] == mark && Board[row, 1] == mark && Board[row, 2] == mark;

            if(markIsInFullRow)
            {
                WinnerId = playerId;
                return;
            }
        }
    }

    private void CheckForVerticalWin(char mark, int playerId)
    {
        for(int col = 0; col < 3; col++)
        {
            bool markIsInFullColumn = Board[0, col] == mark && Board[1, col] == mark && Board[2, col] == mark;

            if(markIsInFullColumn)
            {
                WinnerId = playerId;
                return;
            }
        }
    }

    private void CheckForDiagonalWin(char mark, int playerId)
    {
        bool hasMarkInCenter = Board[1, 1] == mark;
        bool fullMainDiagonalMarked = hasMarkInCenter && Board[0, 0] == mark && Board[2, 2] == mark; 
        bool fullAntiDiagonalMarked = hasMarkInCenter && Board[0, 2] == mark && Board[2, 0] == mark;

        if(fullMainDiagonalMarked || fullAntiDiagonalMarked)
            WinnerId = playerId;
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
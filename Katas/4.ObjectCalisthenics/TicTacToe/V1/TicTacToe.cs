


using Katas.ObjectCalisthenics.TicTacToe.V1.Exceptions;

namespace Katas.ObjectCalisthenics.TicTacToe.V1;

public class TicTacToe
{
    public int WinnerId { get; private set; } = -1;  
    private int _nextToPlayId = 1;
    private BoardTicTacToe _board;

    public TicTacToe(BoardTicTacToe board)
    {
        _board = board;
        _board.InitializeEmptyBoard();
    }

    public char[,] GetCurrentBoard()
    {
        return _board.Board;
    }

    public void PlaceMark(Coords coords)
    {
        bool isEmptyPosition = _board.GetSquare(coords).Equals(' '); 
        if(!isEmptyPosition)
            throw new PlayOnPlayedPositionException($"The position Y: {coords.Y} X: {coords.X} is not empty");

        char mark = _nextToPlayId == 1 ? 'X' : 'O';

        _board.FillSquare(coords, mark);

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
            if(_board.MarkIsInFullRow(row, mark))
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
            if(_board.MarkIsInFullColumn(col, mark))
            {
                WinnerId = playerId;
                return;
            }
        }
    }

    private void CheckForDiagonalWin(char mark, int playerId)
    {
        if(_board.MarkIsInFullMainDiagonal(mark) || _board.MarkIsInFullAntiDiagonal(mark))
            WinnerId = playerId;
    }

    private void UpdateNextPlayerToPlay()
    {
        _nextToPlayId = _nextToPlayId == 1 ? 2 : 1;
    }

}
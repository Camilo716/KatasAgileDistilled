


using Katas.ObjectCalisthenics.TicTacToe.V1.Exceptions;

namespace Katas.ObjectCalisthenics.TicTacToe.V1;

public class TicTacToe
{
    public int WinnerId { get; private set; } = -1;  
    private readonly BoardTicTacToe _board;
    private readonly Player _player1;
    private readonly Player _player2;
    private Player _nextToPlay;

    public TicTacToe(BoardTicTacToe board)
    {
        _board = board;
        _board.InitializeEmptyBoard();

        _player1 = new Player { Id = 1, Mark = 'X'};
        _player2 = new Player { Id = 2, Mark = 'O'};
        _nextToPlay = _player1;
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

        _board.FillSquare(coords, _nextToPlay.Mark);

        CheckForWinner(_nextToPlay);
        UpdateNextPlayerToPlay();
    }

    private void CheckForWinner(Player player)
    {
        CheckForHorizontalWin(player);
        CheckForVerticalWin(player);
        CheckForDiagonalWin(player);
    }

    private void CheckForHorizontalWin(Player player)
    {
        for(int row = 0; row < 3; row++)
        {
            if(_board.MarkIsInFullRow(row, player.Mark))
            {
                WinnerId = player.Id;
                return;
            }
        }
    }

    private void CheckForVerticalWin(Player player)
    {
        for(int col = 0; col < 3; col++)
        {
            if(_board.MarkIsInFullColumn(col, player.Mark))
            {
                WinnerId = player.Id;
                return;
            }
        }
    }

    private void CheckForDiagonalWin(Player player)
    {
        if(_board.MarkIsInFullMainDiagonal(player.Mark) || _board.MarkIsInFullAntiDiagonal(player.Mark))
            WinnerId = player.Id;
    }

    private void UpdateNextPlayerToPlay()
    {
        _nextToPlay = _nextToPlay.Id == 1 ? _player2 : _player1;
    }

}
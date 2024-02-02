using System.Runtime;
using Katas.ObjectCalisthenics.TicTacToe.V1;
using Katas.ObjectCalisthenics.TicTacToe.V1.Exceptions;
using Xunit.Sdk;

namespace Tests.ObjectCalisthenics.V1;

public class TicTacToeShould
{

    [Fact]
    public void InitializeBoard()
    {
        TicTacToe ticTacToe = new();

        char[,] expectedBoard = new char[3,3] {
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {' ', ' ', ' '},
        };
        Assert.Equal(expectedBoard, ticTacToe.Board);
    }

    [Fact]
    public void Player1PlaceFirstMark()
    {
        TicTacToe ticTacToe = new();
        Coords coords = new() { Y = 2, X = 0};
        
        ticTacToe.PlaceMark(coords);

        char[,] expectedBoard = new char[3,3] {
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {'X', ' ', ' '},
        }; 
        Assert.Equal(expectedBoard, ticTacToe.Board);
    }

    [Fact]
    public void Player2PlaceAMark()
    {
        TicTacToe ticTacToe = new();
        Coords p1Coords = new() { Y = 2, X = 0};
        Coords p2Coords = new() { Y = 1, X = 0};
        
        ticTacToe.PlaceMark(p1Coords);
        ticTacToe.PlaceMark(p2Coords);

        char[,] expectedBoard = new char[3,3] {
            {' ', ' ', ' '},
            {'O', ' ', ' '},
            {'X', ' ', ' '},
        };
        Assert.Equal(expectedBoard, ticTacToe.Board);
    }

    [Fact]
    public void CannotPlayOnAPlayedPosition()
    {
        TicTacToe ticTacToe = new();
        Coords p1Coords = new() { Y = 2, X = 0};
        Coords p2Coords = new() { Y = 2, X = 0};
        ticTacToe.PlaceMark(p1Coords);

        Action placeOnAPlayedPosition = () => ticTacToe.PlaceMark(p2Coords);
 
        Assert.Throws<PlayOnPlayedPositionException>(placeOnAPlayedPosition);
    }

    [Fact]
    public void PlayerWinsWithHorizontaly()
    {
        TicTacToe ticTacToe = new();

        ticTacToe.PlaceMark(new() { Y = 2, X = 0});
        ticTacToe.PlaceMark(new() { Y = 1, X = 0});
        ticTacToe.PlaceMark(new() { Y = 2, X = 1});
        ticTacToe.PlaceMark(new() { Y = 0, X = 0});
        ticTacToe.PlaceMark(new() { Y = 2, X = 2});

       char[,] expectedBoard = new char[3,3] {
            {'O', ' ', ' '},
            {'O', ' ', ' '},
            {'X', 'X', 'X'},
        };
        Assert.Equal(expectedBoard, ticTacToe.Board);
        Assert.Equal(1, ticTacToe.WinnerId);
    }

    [Fact]
    public void PlayerWinsVertically()
    {
        TicTacToe ticTacToe = new();
        
        ticTacToe.PlaceMark(new() { Y = 2, X = 0});
        ticTacToe.PlaceMark(new() { Y = 1, X = 1});
        ticTacToe.PlaceMark(new() { Y = 1, X = 0});
        ticTacToe.PlaceMark(new() { Y = 1, X = 2});
        ticTacToe.PlaceMark(new() { Y = 0, X = 0});

       char[,] expectedBoard = new char[3,3] {
            {'X', ' ', ' '},
            {'X', 'O', 'O'},
            {'X', ' ', ' '},
        };   
        Assert.Equal(expectedBoard, ticTacToe.Board);
        Assert.Equal(1, ticTacToe.WinnerId);
    }

    [Fact]
    public void PlayerWinsDiagonally()
    {
        TicTacToe ticTacToe = new();

        ticTacToe.PlaceMark(new() { Y = 2, X = 0});
        ticTacToe.PlaceMark(new() { Y = 1, X = 0});
        ticTacToe.PlaceMark(new() { Y = 0, X = 2});
        ticTacToe.PlaceMark(new() { Y = 2, X = 2});
        ticTacToe.PlaceMark(new() { Y = 1, X = 1});

        char[,] expectedBoard = new char[3, 3] {
            {' ', ' ', 'X'},
            {'O', 'X', ' '},
            {'X', ' ', 'O'},   
        };
        Assert.Equal(expectedBoard, ticTacToe.Board);
        Assert.Equal(1, ticTacToe.WinnerId);
    }

    [Fact]
    public void AllSquaresFilledWithoutThreeInARowIsADraw()
    {
        TicTacToe ticTacToe = new();

        ticTacToe.PlaceMark(new() { Y = 2, X = 0});
        ticTacToe.PlaceMark(new() { Y = 0, X = 0});
        ticTacToe.PlaceMark(new() { Y = 0, X = 2});
        ticTacToe.PlaceMark(new() { Y = 1, X = 1});
        ticTacToe.PlaceMark(new() { Y = 2, X = 2});
        ticTacToe.PlaceMark(new() { Y = 1, X = 2});
        ticTacToe.PlaceMark(new() { Y = 0, X = 1});
        ticTacToe.PlaceMark(new() { Y = 2, X = 1});
        ticTacToe.PlaceMark(new() { Y = 1, X = 0});

        char[,] expectedBoard = new char[3, 3] {
            {'O', 'X', 'X'},
            {'X', 'O', 'O'},
            {'X', 'O', 'X'},   
        };
        Assert.Equal(expectedBoard, ticTacToe.Board);
        Assert.Equal(-1, ticTacToe.WinnerId);
    }
}
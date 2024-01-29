using Katas.ObjectCalisthenics.TicTacToe.V1;

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
}
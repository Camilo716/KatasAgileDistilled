namespace Katas.ObjectCalisthenics.TicTacToe.V1;

public class BoardTicTacToe
{
    public char[,] Board { get; set; }

    public void InitializeEmptyBoard()
    {
        Board = new char[3,3] {
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {' ', ' ', ' '},
        };
    }

    public void FillSquare(Coords coords, char mark)
    {
        Board[coords.Y, coords.X] = mark;
    }

    public char GetSquare(Coords coords)
    {
        return Board[coords.Y, coords.X];
    }

    public bool MarkIsInFullRow(int row, char mark)
    {   
        return Board[row, 0] == mark && Board[row, 1] == mark && Board[row, 2] == mark;
    }

    public bool MarkIsInFullColumn(int column, char mark)
    {
        return Board[0, column] == mark && Board[1, column] == mark && Board[2, column] == mark;
    }

    public bool MarkIsInFullMainDiagonal(char mark)
    {
        return Board[1, 1] == mark && Board[0, 0] == mark && Board[2, 2] == mark;
    }

    public bool MarkIsInFullAntiDiagonal(char mark)
    {
        return Board[1, 1] == mark && Board[0, 2] == mark && Board[2, 0] == mark;
    }


}
public class CheckingGameState
{
    private readonly Board _board;

    public CheckingGameState(Board board)
    {
        _board = board;
    }

    public bool IsWin()
    {
        for (int row = 0; row < Board.Size; row++)
        {
            for (int column = 0; column < Board.Size; column++)
            {
                if (_board.GetCells(row, column) == 2048)
                    return true;
            }
        }

        return false;
    }

    public bool IsLose()
    {
        if (IsBoardFull() && !IsOneMoreMove())
            return true;
        
        return false;
    }

    public bool IsBoardFull()
    {
        for (int row = 0; row < Board.Size; row++)
        {
            for (int column = 0; column < Board.Size; column++)
            {
                if (_board.IsCellEmpty(row, column))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public bool IsOneMoreMove()
    {
        for (int row = 0; row < Board.Size; row++)
        {
            for (int column = 0; column < Board.Size; column++)
            {
                if (row + 1 < Board.Size && _board.GetCells(row, column) == _board.GetCells(row + 1, column) ||
                    column + 1 < Board.Size && _board.GetCells(row, column) == _board.GetCells(row, column + 1))
                {
                    return true;
                }
            }
        }

        return false;
    }
}
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    public const int Size = 4;
    private readonly int [,] grid = new int [Size, Size];

    public int GetCells(int row, int column)
    {
        return grid[row, column];
    }

    public void SetCells(int row, int column, int number)
    {
        grid[row, column] = number;
    }
    
    public void ResetCells()
    {
        for (int row = 0; row < Size; row++)
        {
            for (int column = 0; column < Size; column++)
            {
                SetCells(row, column, 0);
            }
        }
    }

    public bool IsCellEmpty(int row, int column)
    {
        return grid[row, column] == 0;
    }

    public List<Vector2Int> GetEmptyCells()
    {
        List<Vector2Int> cells = new List<Vector2Int>();
        
        for (int row = 0; row < Size; row++)
        {
            for (int column = 0; column < Size; column++)
            {
                if (IsCellEmpty(row, column))
                    cells.Add(new Vector2Int(row, column));
            }
        }
        
        return cells;
    }

    public int[,] GetBoardClone()
    {
        int[,] cloneGrid = new int[Size, Size];
        
        for (int row = 0; row < Size; row++)
        {
            for (int column = 0; column < Size; column++)
            {
                cloneGrid[row, column] = GetCells(row, column);
            }
        }
        
        return cloneGrid;
    }
}
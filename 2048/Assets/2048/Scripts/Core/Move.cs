using System;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    private readonly GridManager _gridManager;
    private readonly TileManager _tileManager;


    public Move(GridManager gridManager, TileManager tileManager)
    {
        _gridManager = gridManager;
        _tileManager = tileManager;
    }

    public int[] TakeRow(int row)
    {
        int[] rowValue = new int[Board.Size];

        for (int i = 0; i < rowValue.Length; i++)
        {
            rowValue[i] = _gridManager.Board.GetCells(row, i);
        }

        return rowValue;
    }

    public int[] TakeColumn(int column)
    {
        int[] columnValue = new int[Board.Size];

        for (int i = 0; i < columnValue.Length; i++)
        {
            columnValue[i] = _gridManager.Board.GetCells(i, column);
        }
        
        return columnValue;
    }

    public void SaveRow(int row, List<int> value)
    {
        for (int i = 0; i < Board.Size; i++)
        {
            _gridManager.Board.SetCells(row, i, value[i]);
        }
    }

    public void SaveColumn(int column, List<int> value)
    {
        for (int i = 0; i < Board.Size; i++)
        {
            _gridManager.Board.SetCells(i, column, value[i]);
        }
    }

    public (int score, bool isMoved) UpMove()
    {
        int score = 0;
        int lineScore = 0;
        bool isMoved = false;
        
        List<int> tilesValue = new List<int>();

        for (int column = 0; column < Board.Size; column++)
        {
            int[] columnValue = TakeColumn(column);
            
            (tilesValue, lineScore) = _tileManager.TileMerge(columnValue);

            for (int i = 0; i < Board.Size; i++)
            {
                if (tilesValue[i] != columnValue[i])
                    isMoved = true;
            }
            
            score += lineScore;
            SaveColumn(column, tilesValue);
        }
        
        return (score, isMoved);
    }
    
    public (int score, bool isMoved) DownMove()
    {
        int score = 0;
        int lineScore = 0;
        bool isMoved = false;
        
        List<int> tilesValue = new List<int>();

        for (int column = 0; column < Board.Size; column++)
        {
            int[] columnValue = TakeColumn(column);
            int[] originalColumn = (int[])columnValue.Clone();
            Array.Reverse(columnValue);
            
            (tilesValue, lineScore) = _tileManager.TileMerge(columnValue);
            tilesValue.Reverse();

            for (int i = 0; i < Board.Size; i++)
            {
                if (tilesValue[i] != originalColumn[i])
                    isMoved = true;
            }
            
            score += lineScore;
            SaveColumn(column, tilesValue);
        }
        
        return (score, isMoved);
    }

    public (int score, bool isMoved) LeftMove()
    {
        int score = 0;
        int lineScore = 0;
        bool isMoved = false;
        
        List<int> tilesValue = new List<int>();

        for (int row = 0; row < Board.Size; row++)
        {
            int[] rowValue = TakeRow(row);

            (tilesValue, lineScore) = _tileManager.TileMerge(rowValue);

            for (int i = 0; i < Board.Size; i++)
            {
                if (tilesValue[i] != rowValue[i])
                    isMoved = true;
            }

            score += lineScore;
            SaveRow(row, tilesValue);
        }

        return (score, isMoved);
    }
    
    public (int score, bool isMoved) RightMove()
    {
        int score = 0;
        int lineScore = 0;
        bool isMoved = false;
        
        List<int> tilesValue = new List<int>();

        for (int row = 0; row < Board.Size; row++)
        {
            int[] rowValue = TakeRow(row);
            int[] originalRow = (int[])rowValue.Clone();
            Array.Reverse(rowValue);

            (tilesValue, lineScore) = _tileManager.TileMerge(rowValue);
            tilesValue.Reverse();

            for (int i = 0; i < Board.Size; i++)
            {
                if (tilesValue[i] != originalRow[i])
                    isMoved = true;
            }

            score += lineScore;
            SaveRow(row, tilesValue);
        }

        return (score, isMoved);
    }
}
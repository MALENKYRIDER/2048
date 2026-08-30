using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public List<int> CompressLine(int[] line) //deleted zero, leave only tiles with numbers
    {
        List<int> tiles = new List<int>();

        for (int row = 0; row < line.Length; row++)
        {
            if (line[row] != 0)
                tiles.Add(line[row]);
        }

        return tiles;
    }

    public (List<int> tiles, int score) MergeTiles (List<int> compressedLine)  //merge same tiles if they're close 
    {
        List<int> merge = new List<int>();

        int score = 0;

        for (int line = 0; line < compressedLine.Count;)
        {
            if (line + 1 < compressedLine.Count && compressedLine[line] == compressedLine[line + 1])
            {
                merge.Add(compressedLine[line] * 2);
                score += compressedLine[line] * 2;
                line += 2;
            }
            else
            {
                merge.Add(compressedLine[line]);
                line += 1;
            }
        }
        
        return (merge, score);
    }

    public List<int> AddZero(List<int> mergeLine) //add zero at the end of the List 
    {
        List<int> zero = new List<int>();

        foreach (int i in mergeLine)
        {
            zero.Add(i);
        }

        while (zero.Count < Board.Size)
        {
            zero.Add(0);
        }

        return zero;
    }

    public (List<int> result, int score) TileMerge(int[] line)
    {
        List<int> compressResult = CompressLine(line);
        (List<int> mergeResult, int mergeScore) = MergeTiles(compressResult);
        List<int> addZeroResult = AddZero(mergeResult);
        
        return (addZeroResult, mergeScore);
    }
}
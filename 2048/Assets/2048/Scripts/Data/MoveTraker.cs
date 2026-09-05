using System.Collections.Generic;

public class MoveTraker
{
    public List<(int from, int to, bool isMerged)> Comprasion(int[] oldLine, int[] newLine)
    {
        List<(int value, int index)> oldCells = GetOnlyFilledCells(oldLine);
        List<(int value, int index)> newCells = GetOnlyFilledCells(newLine);
        
        List<(int from, int to, bool isMerged)> result = new List<(int from, int to, bool isMerged)>();
        int newPointer = 0;
        
        for (int oldPointer = 0; oldPointer < oldCells.Count;)
        {
            if (oldPointer + 1 < oldCells.Count && oldCells[oldPointer].value ==  oldCells[oldPointer + 1].value)
            {
                result.Add((oldCells[oldPointer].index, newCells[newPointer].index, true));
                result.Add((oldCells[oldPointer + 1].index, newCells[newPointer].index, true));
                oldPointer += 2;
                newPointer += 1 ;
            }
            else
            {
                result.Add((oldCells[oldPointer].index, newCells[newPointer].index, false));
                oldPointer += 1;
                newPointer += 1;
            }
        }
        
        return result;
    }

    private List<(int value, int index)> GetOnlyFilledCells(int[] line)
    {
        List<(int value, int index)> checkLine = new List<(int value, int index)>();

        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] != 0)
                checkLine.Add((line[i], i));
        }

        return checkLine;
    }
}
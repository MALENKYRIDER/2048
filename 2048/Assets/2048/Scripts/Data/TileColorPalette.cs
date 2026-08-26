using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TileColor", menuName = "TileColorPalette")]
public class TileColor : ScriptableObject
{
    public List<TilesInfo> tilesInfo = new List<TilesInfo>();

    public Color GetColor(int value)
    {
        foreach (var num in tilesInfo)
        {
            if (value == num.number)
            {
                return num.color;
            }
        }
        
        return Color.clear;
    }
}

[System.Serializable]
public class TilesInfo
{
    public int number;
    public Color color;
}
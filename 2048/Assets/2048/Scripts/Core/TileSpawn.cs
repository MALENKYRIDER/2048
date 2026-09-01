using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TileSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _tilesBox;
    [SerializeField] private GridManager _gridManager;

    private void Start()
    {
        SpawnRandomTile();
        SpawnRandomTile();
    }

    private void SpawnRandomTile()
    {
        List<Vector2Int> emptyCells = _gridManager.Board.GetEmptyCells();
        int randomIndex = Random.Range(0, emptyCells.Count);
        
        Vector2Int correctCell = emptyCells[randomIndex];
        int row = correctCell.x;
        int column = correctCell.y;

        var random = Random2or4();
        _gridManager.Board.SetCells(row, column, random);
        
        var tile = Instantiate(_tilePrefab, _tilesBox);
        tile.GetComponent<RectTransform>().anchoredPosition = _gridManager.GetCellCenter(row, column);
        tile.GetComponent<TileVisual>().SetupTile(random); 
    }

    public void SpawnTileAfterMove()
    {
        SpawnRandomTile();
    }

    private int Random2or4()
    {
        int random = Random.Range(0, 100);
        if (random <= 89)
            random = 2;
        else
        {
            random = 4;
        }
        
        return random;
    }
}
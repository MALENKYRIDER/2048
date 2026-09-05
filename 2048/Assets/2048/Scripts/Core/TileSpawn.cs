using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TileSpawn : MonoBehaviour
{
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private BoardRenderer _boardRenderer;
    [SerializeField] private MoveManager _moveManager;

    private void Start()
    {
        if (_moveManager.SaveGameService.LoadGame())
        {
            _boardRenderer.Rebuild();
        }
        else
        {
            SpawnRandomTile();
            SpawnRandomTile();
            _boardRenderer.Rebuild();
        }
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
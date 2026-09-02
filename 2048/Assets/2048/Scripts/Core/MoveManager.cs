using System;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    public Move Move { get; private set; }

    [SerializeField] private InputManager _inputManager;
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private TileManager _tileManager;
    [SerializeField] private TileSpawn _tileSpawn;
    [SerializeField] private BoardRenderer _boardRenderer;

    private void Awake()
    {
        Move = new Move(_gridManager, _tileManager);
    }

    public void UpMove()
    {
        (int score, bool isMoved) = Move.UpMove();
        if (isMoved)
        {
            _tileSpawn.SpawnTileAfterMove();
            _boardRenderer.Rebuild();
        }
    }
    
    public void DownMove()
    {
        (int score, bool isMoved) = Move.DownMove();
        if (isMoved)
        {
            _tileSpawn.SpawnTileAfterMove();
            _boardRenderer.Rebuild();
        }
    }

    public void LeftMove()
    {
        (int score, bool isMoved) = Move.LeftMove();
        if (isMoved)
        {
            _tileSpawn.SpawnTileAfterMove();
            _boardRenderer.Rebuild();
        }
    }

    public void RightMove()
    {
        (int score, bool isMoved) = Move.RightMove();
        if (isMoved)
        {
            _tileSpawn.SpawnTileAfterMove();
            _boardRenderer.Rebuild();
        }
    }
}
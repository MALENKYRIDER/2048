using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    public Move Move { get; private set; }

    [SerializeField] private InputManager _inputManager;
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private TileManager _tileManager;
    [SerializeField] private TileSpawn _tileSpawn;
    [SerializeField] private BoardRenderer _boardRenderer;
    [SerializeField] private MoveAnimator _moveAnimator;

    private void Awake()
    {
        MoveTraker moveTraker = new MoveTraker();
        Move = new Move(_gridManager, _tileManager, moveTraker);
    }

    private IEnumerator MoveCoroutine(List<(Vector2Int from, Vector2Int to, bool isMerged)> instruction)
    {
        yield return StartCoroutine(_moveAnimator.MoveAnim(instruction));
        _tileSpawn.SpawnTileAfterMove();
        _boardRenderer.Rebuild();
    }

    public void UpMove()
    {
        (int score, bool isMoved, List<(Vector2Int from, Vector2Int to, bool isMerged)> instruction) = Move.UpMove();

        if (isMoved)
        {
            StartCoroutine(MoveCoroutine(instruction));
        }
    }

    public void DownMove()
    {
        (int score, bool isMoved, List<(Vector2Int from, Vector2Int to, bool isMerged)> instruction) = Move.DownMove();

        if (isMoved)
        {
            StartCoroutine(MoveCoroutine(instruction));
        }
    }

    public void LeftMove()
    {
        (int score, bool isMoved, List<(Vector2Int from, Vector2Int to, bool isMerged)> instruction) = Move.LeftMove();

        if (isMoved)
        {
            StartCoroutine(MoveCoroutine(instruction));
        }
    }

    public void RightMove()
    {
        (int score, bool isMoved, List<(Vector2Int from, Vector2Int to, bool isMerged)> instruction) = Move.RightMove();

        if (isMoved)
        {
            StartCoroutine(MoveCoroutine(instruction));
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    public Move Move { get; private set; }
    public CheckingGameState CheckingGameState { get; private set; }
    public SaveGameService SaveGameService { get; private set; }

    [SerializeField] private InputManager _inputManager;
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private TileManager _tileManager;
    [SerializeField] private TileSpawn _tileSpawn;
    [SerializeField] private BoardRenderer _boardRenderer;
    [SerializeField] private MoveAnimator _moveAnimator;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private PopupManager _popupManager;

    private bool _isBlocked = false;
    private bool _wasWin = false;

    private void Awake()
    {
        MoveTraker moveTraker = new MoveTraker();
        Move = new Move(_gridManager, _tileManager, moveTraker);
        CheckingGameState = new CheckingGameState(_gridManager.Board);
        SaveGameService = new SaveGameService(_gridManager, _scoreManager);
    }

    public void Block()
    {
        _isBlocked = true;
    }
    
    public void Unblock()
    {
        _isBlocked = false;
    }

    public void ResetWin()
    {
        _wasWin = false;
    }

    private IEnumerator MoveCoroutine(List<(Vector2Int from, Vector2Int to, bool isMerged)> instruction)
    {
        yield return StartCoroutine(_moveAnimator.MoveAnim(instruction));
        _tileSpawn.SpawnTileAfterMove();
        _boardRenderer.Rebuild();
        SaveGameService.SaveGame();
        
        bool isLose = CheckingGameState.IsLose();
        bool isWin = CheckingGameState.IsWin(); 

        if (isLose)
        {
            _isBlocked = true;
            _popupManager.ShowLosePopup();
        }
        else if (isWin && !_wasWin)
        {
            _isBlocked = true;
            _wasWin = true;
            _popupManager.ShowWinPopup();
        }
        else
        {
             _isBlocked = false;
        }
    }

    public void UpMove()
    {
        if (_isBlocked == true)
            return;

        (int score, bool isMoved, List<(Vector2Int from, Vector2Int to, bool isMerged)> instruction) = Move.UpMove();

        if (isMoved)
        {
            _isBlocked = true;
            StartCoroutine(MoveCoroutine(instruction));
            _scoreManager.Score(score);
        }
    }

    public void DownMove()
    {
        if (_isBlocked == true)
            return;

        (int score, bool isMoved, List<(Vector2Int from, Vector2Int to, bool isMerged)> instruction) = Move.DownMove();

        if (isMoved)
        {
            _isBlocked = true;
            StartCoroutine(MoveCoroutine(instruction));
            _scoreManager.Score(score);
        }
    }

    public void LeftMove()
    {
        if (_isBlocked == true)
            return;

        (int score, bool isMoved, List<(Vector2Int from, Vector2Int to, bool isMerged)> instruction) = Move.LeftMove();

        if (isMoved)
        {
            _isBlocked = true;
            StartCoroutine(MoveCoroutine(instruction));
            _scoreManager.Score(score);
        }
    }

    public void RightMove()
    {
        if (_isBlocked == true)
            return;

        (int score, bool isMoved, List<(Vector2Int from, Vector2Int to, bool isMerged)> instruction) = Move.RightMove();

        if (isMoved)
        {
            _isBlocked = true;
            StartCoroutine(MoveCoroutine(instruction));
            _scoreManager.Score(score);
        }
    }
}
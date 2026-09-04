using System;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private GameObject _losePopup;
    [SerializeField] private GameObject _winPopup;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _restartLoseButton;
    [SerializeField] private Button _restartWinButton;
    [SerializeField] private Button _continueButton;

    [SerializeField] private GridManager _gridManager;
    [SerializeField] private TileSpawn _tileSpawn;
    [SerializeField] private BoardRenderer _boardRenderer;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private MoveManager _moveManager;

    private void Awake()
    {
        _losePopup.SetActive(false);
        _winPopup.SetActive(false);
    }

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _restartLoseButton.onClick.AddListener(OnRestartLoseButtonClick);
        _restartWinButton.onClick.AddListener(OnRestartWinButtonClick);
        _continueButton.onClick.AddListener(OnContinueButtonClick);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _restartLoseButton.onClick.RemoveListener(OnRestartLoseButtonClick);
        _restartWinButton.onClick.RemoveListener(OnRestartWinButtonClick);
        _continueButton.onClick.RemoveListener(OnContinueButtonClick);
    }


    private void OnContinueButtonClick()
    {
        _winPopup.SetActive(false);
        _moveManager.Unblock();
    }

    private void OnRestartWinButtonClick()
    {
        Restart();
        _winPopup.SetActive(false);
    }

    private void OnRestartLoseButtonClick()
    {
        Restart();
        _losePopup.SetActive(false);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void Restart()
    {
        _gridManager.Board.ResetCells();
        _tileSpawn.SpawnTileAfterMove();
        _tileSpawn.SpawnTileAfterMove();
        _boardRenderer.Rebuild();
        _scoreManager.ResetScore();
        _moveManager.Unblock();
        _moveManager.ResetWin();
    }

    public void ShowLosePopup()
    {
        _losePopup.SetActive(true);
    }

    public void ShowWinPopup()
    {
        _winPopup.SetActive(true);
    }
}
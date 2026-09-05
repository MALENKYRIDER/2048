using System;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    [Header("Win/Lose Elements")]
    [SerializeField] private GameObject _losePopup;
    [SerializeField] private GameObject _winPopup;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _restartLoseButton;
    [SerializeField] private Button _restartWinButton;
    [SerializeField] private Button _continueButton;

    [Header("Menu")] 
    [SerializeField] private GameObject _menuPopup;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _continueMenuButton;
    [SerializeField] private Button _restartMenuButton;
    [SerializeField] private Button _quitMenuButton;
    
    [Header("Board Elements")]
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private TileSpawn _tileSpawn;
    [SerializeField] private BoardRenderer _boardRenderer;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private MoveManager _moveManager;
    
    private void Awake()
    {
        _losePopup.SetActive(false);
        _winPopup.SetActive(false);
        _menuPopup.SetActive(false);
    }

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _restartLoseButton.onClick.AddListener(OnRestartLoseButtonClick);
        _restartWinButton.onClick.AddListener(OnRestartWinButtonClick);
        _continueButton.onClick.AddListener(OnContinueButtonClick);
        
        _menuButton.onClick.AddListener(OnMenuButtonClick);
        _continueMenuButton.onClick.AddListener(OnContinueMenuButtonClick);
        _restartMenuButton.onClick.AddListener(OnRestartMenuButtonClick);
        _quitMenuButton.onClick.AddListener(OnQuitMenuButtonClick);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _restartLoseButton.onClick.RemoveListener(OnRestartLoseButtonClick);
        _restartWinButton.onClick.RemoveListener(OnRestartWinButtonClick);
        _continueButton.onClick.RemoveListener(OnContinueButtonClick);
        
        _menuButton.onClick.RemoveListener(OnMenuButtonClick);
        _continueMenuButton.onClick.RemoveListener(OnContinueMenuButtonClick);
        _restartMenuButton.onClick.RemoveListener(OnRestartMenuButtonClick);
        _quitMenuButton.onClick.RemoveListener(OnQuitMenuButtonClick);
    }

    private void OnQuitMenuButtonClick()
    {
        Application.Quit();
    }

    private void OnRestartMenuButtonClick()
    {
        Restart();
        _menuPopup.SetActive(false);
    }

    private void OnContinueMenuButtonClick()
    {
        _menuPopup.SetActive(false);
        _moveManager.Unblock();
    }

    private void OnMenuButtonClick()
    {
        _moveManager.Block();
        _menuPopup.SetActive(true);
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
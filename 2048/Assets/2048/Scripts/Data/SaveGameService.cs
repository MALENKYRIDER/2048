using UnityEngine;

public class SaveGameService
{
    private readonly GridManager _gridManager;
    private readonly ScoreManager _scoreManager;

    public SaveGameService(GridManager gridManager, ScoreManager scoreManager)
    {
        _gridManager = gridManager;
        _scoreManager = scoreManager;
    }

    public void SaveGame()
    {
        for (int row = 0; row < Board.Size; row++)
        {
            for (int column = 0; column < Board.Size; column++)
            {
                PlayerPrefs.SetInt($"Cell_{row}_{column}", _gridManager.Board.GetCells(row, column));
            }
        }

        _scoreManager.SaveScore();
        PlayerPrefs.SetInt("HasSaved", 1);
    }

    public bool LoadGame()
    {
        if (PlayerPrefs.HasKey("HasSaved") && PlayerPrefs.GetInt("HasSaved") == 1)
        {
            for (int row = 0; row < Board.Size; row++)
            {
                for (int column = 0; column < Board.Size; column++)
                {
                    _gridManager.Board.SetCells(row, column, PlayerPrefs.GetInt($"Cell_{row}_{column}", 0));
                }
            }

            _scoreManager.LoadScore();
            
            return true;
        }
        
        return false;
    }
}
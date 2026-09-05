using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _bestScoreText;

    private int _score;
    private int _bestScore;

    private void Awake()
    {
        _bestScore = PlayerPrefs.GetInt("BestScore", 0);
        _bestScoreText.text = _bestScore.ToString();
    }

    public void Score(int addScore)
    {
        _score += addScore;
        _scoreText.text = _score.ToString();

        if (_score > _bestScore)
        {
            _bestScore = _score;
            PlayerPrefs.SetInt("BestScore", _bestScore);
            _bestScoreText.text = _bestScore.ToString();
        }
    }

    public void ResetScore()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
    }
}
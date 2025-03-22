using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _GameOverView : MonoBehaviour
{

    [SerializeField] private Image _background;
    [SerializeField] private TextMeshProUGUI _gameOverTitle;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    public void SetGameOver(string title, int score, int highScore)
    {
        _gameOverTitle.text = title;
        _scoreText.text = "Score: " + score;
        _highScoreText.text = "High Score: " + highScore;
    }
}

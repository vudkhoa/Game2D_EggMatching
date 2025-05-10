using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _GameOverView : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(Replay);
    }

    public void SetScoreText(int score)
    {
        this.scoreText.text = score.ToString();
    }
    
    public void Replay()
    {
        _UIManager.instance.ReplayGame();
    }
}

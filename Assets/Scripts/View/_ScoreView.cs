using TMPro;
using UnityEngine;

public class _ScoreView : MonoBehaviour
{
    private TextMeshProUGUI scoreText;


    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    public void InitScoreView(int sc)
    {
        if (scoreText == null) return;
        scoreText.text = "Score: " + sc.ToString();
    }

    public void SetScoreView(int score) 
    { 
        scoreText.text = "Score: " + score.ToString();
    }
}

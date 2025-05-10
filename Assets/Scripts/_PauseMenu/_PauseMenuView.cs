using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class _PauseMenuView : MonoBehaviour
{
    public Button continueButton;
    public TextMeshProUGUI textScore;

    private void Start()
    {
        continueButton.onClick.AddListener(ContinueGame);
    }

    public virtual void ContinueGame()
    {
        _UIManager.instance.StartGame();
    }

    public void SetTextScore(int score)
    {
        this.textScore.text = "Score: " + score.ToString();
    }

}

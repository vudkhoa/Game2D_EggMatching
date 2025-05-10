using UnityEngine;

public class _GameOverManager : MonoBehaviour
{
    static _GameOverManager instance;
    public GameObject gameOverPrefab;
    public GameObject gameOver;
    public Transform panelParent;
    public _GameOverView gameOverView;

    private void Awake()
    {
        _GameOverManager.instance = this;
        this.gameOver = Instantiate(gameOverPrefab, panelParent);
        this.gameOverView = this.gameOver.GetComponent<_GameOverView>();
        this.gameOver.SetActive(false);
    }

    public void ShowUI()
    {
        this.gameOver.SetActive(true);
    }

    public void HideUI()
    {
        this.gameOver.SetActive(false);
    }
}

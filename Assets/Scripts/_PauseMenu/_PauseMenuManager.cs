using UnityEngine;

public class _PauseMenuManager : MonoBehaviour
{
    static public _PauseMenuManager instance;
    public Transform parentPanel;
    public GameObject pauseMenuPrefab;
    public GameObject pauseMenu;
    public _PauseMenuView pauseMenuView;


    private void Awake()
    {
        _PauseMenuManager.instance = this;
        this.pauseMenu = Instantiate(this.pauseMenuPrefab, this.parentPanel);
        this.pauseMenuView = this.pauseMenu.GetComponent<_PauseMenuView>();
        this.pauseMenu.SetActive(false);
    }

    public virtual void ShowUI(int score)
    {
        this.pauseMenuView.SetTextScore(score);
        this.pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public virtual void HideUI()
    {
        this.pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}

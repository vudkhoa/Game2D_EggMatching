using UnityEngine;

public class _UIManager : MonoBehaviour
{
    public static _UIManager instance;
    public _PauseMenuManager pauseMenuManager;
    public _MainMenuManager mainMenuManage;
    public _GameOverManager gameOverManager;

    private void Awake()
    {
        _UIManager.instance = this;
    }

    public Transform GetTrasformMainMenu()
    {
        return this.mainMenuManage.mainMenu.transform;
    }
    
    public void PauseGame(int score)
    {
        this.pauseMenuManager.ShowUI(score);
        this.mainMenuManage.HideUI();
        this.gameOverManager.HideUI();
    }

    public void StartGame()
    {
        this.mainMenuManage.ShowUI();
        this.pauseMenuManager.HideUI();
        this.gameOverManager.HideUI();
    }

    public void GameOver()
    {
        this.mainMenuManage.HideUI();
        this.pauseMenuManager.HideUI();
        this.gameOverManager.ShowUI();
    }

    public void ReplayGame()
    {
        this.mainMenuManage.ShowUI();
        this.pauseMenuManager.HideUI();
        this.gameOverManager.HideUI();
    }

}

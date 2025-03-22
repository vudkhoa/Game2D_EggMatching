using UnityEngine;

public class _UIManager : MonoBehaviour
{
    public static _UIManager Instance;

    [Header("UI Panels")]
    public Transform panelParent;
    public GameObject _gameOverPrefab;
    public GameObject _hudPanel;

    private _GameOverView gameOverView;
    private GameObject _gameOverInstance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Tạo GameOver UI một lần duy nhất
        _gameOverInstance = Instantiate(_gameOverPrefab, panelParent);
        gameOverView = _gameOverInstance.GetComponent<_GameOverView>();
        _gameOverInstance.SetActive(false);
    }

    public void ShowHUD()
    {
        _gameOverInstance.SetActive(false);
        _hudPanel.SetActive(true);
    }

    public void ShowGameOver(string title, int score, int highScore)
    {
        gameOverView.SetGameOver(title, score, highScore);
        _gameOverInstance.SetActive(true);
        _hudPanel.SetActive(false);
    }
}

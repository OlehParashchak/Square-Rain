using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameStartScreen;
    [SerializeField]
    private GameObject _gameScreen;
    [SerializeField]
    private GameObject _gameOverScreen;

    [SerializeField]
    private float _gameOverScreenShowDelay;//задержка до появления экрана окончания игры

    private bool _wasGameOver;

    public InterstitialAds ad;
    private void Awake()
    {
        _gameScreen.SetActive(false);
        _gameOverScreen.SetActive(false);
        _gameStartScreen.SetActive(true);
    }

    private void Update()
    {
        if (_wasGameOver)
        {
            _gameOverScreenShowDelay -= Time.deltaTime;

            if (_gameOverScreenShowDelay <= 0)
            {
                ShowGameOverScreen();
            }
        }
    }

    public void StartGame()
    {
        _gameStartScreen.SetActive(false);
        _gameScreen.SetActive(true);
    }

    public void RestartGame()
    {
        ad.ShowAd();
        var sceneName = SceneManager.GetActiveScene().name;//получаем название сцены
        SceneManager.LoadSceneAsync(sceneName);//загружаем данную сцену
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void OnPlayerDied()
    {
        _wasGameOver = true;
    }

    private void ShowGameOverScreen()
    {
        _gameScreen.SetActive(false);
        _gameOverScreen.SetActive(true);
    }
}
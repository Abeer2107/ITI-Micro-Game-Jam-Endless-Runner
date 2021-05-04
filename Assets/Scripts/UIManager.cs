using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameoverMenu;

    string sceneName;
    bool isStarted = false;
    bool isPaused = false;

    public delegate void GameStartedEvent();
    public static event GameStartedEvent GameStarted;

    private void OnEnable()
    {
        GameManager.UpdateScore += SetScore;
        ScrollingObject.PlayerHit += ShowGameOver;
        Destroyer.PlayerOutOfBound += ShowGameOver;
    }
    private void OnDisable()
    {
        GameManager.UpdateScore -= SetScore;
        ScrollingObject.PlayerHit -= ShowGameOver;
        Destroyer.PlayerOutOfBound -= ShowGameOver;
    }
    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isStarted)
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void StartGame()
    {
        isStarted = true;
        scoreText.gameObject.SetActive(true);
        GameStarted.Invoke();
    }

    public void QuitGame()
    {
        Application.Quit(0);
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
    }

    public void ShowGameOver()
    {
        gameoverMenu.SetActive(true);
        isStarted = false;
        Time.timeScale = 0;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }
}

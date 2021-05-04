using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] float levelSpeed;
    int score;
    float timer = 0;

    public delegate void UpdateScoreEvent(int score);
    public delegate void UpdateDifficultyEvent(float levelSpeed);

    public static event UpdateScoreEvent UpdateScore;
    public static event UpdateDifficultyEvent UpdateDifficulty;


    static GameManager instance = null;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }

    private void OnEnable()
    {
        UIManager.GameStarted += StartGame;
    }
    private void OnDisable()
    {
        UIManager.GameStarted -= StartGame;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Time.timeScale = 0;

        player.gameObject.SetActive(false);
        UpdateDifficulty.Invoke(levelSpeed);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        score = 0;
        player.gameObject.SetActive(true);
    }

    public void gameOver()
    {
        Time.timeScale = 0;
    }


    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1)
        {
            score++;
            UpdateScore.Invoke(score);
            timer = 0;
        }

        //if(this.score % 50 == 0)
        //{
        //    this.speed++;
        //    for (int i = 0; i < obstaclesSpawner.obj.Length; i++)
        //    {
        //        obstaclesSpawner.obj[i].GetComponent<Obstacles>().speed = this.speed;
        //    }
        //}

    }
}

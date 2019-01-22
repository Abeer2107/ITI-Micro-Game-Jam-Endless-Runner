using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public UIManager ui;
    public Spawner obstaclesSpawner;
    public float speed;
    public bool isPaused;
    int score;
    public Text scoreCounter;
    float timer = 0;

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


    void Start()
    {
        DontDestroyOnLoad(gameObject);
        ui.showMainMenu();
        player.gameObject.SetActive(false);
        FindObjectOfType<AudioManager>().playMainMenu();
        Time.timeScale = 0;  
        for(int i = 0; i < obstaclesSpawner.obj.Length; i++)
        {
            obstaclesSpawner.obj[i].GetComponent<Obstacles>().speed = this.speed;
        }
    }

    public void startGame()
    {
        score = 0;
        //obstaclesSpawner.gameObject.SetActive(true);
        FindObjectOfType<AudioManager>().playGameplay();
        Time.timeScale = 1;
        player.gameObject.SetActive(true);
        ui.hideMainMenu();
        resumeGame();
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        ui.showGameOverMenu();
        //obstaclesSpawner.gameObject.SetActive(false);
    }

    public void reloadScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void quitGame()
    {
        Application.Quit(0);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1)
        {
            score++;
            scoreCounter.text = score.ToString();
            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused && ui.mainMenuOn == false)
        {
            ui.showPauseMenu();
            pauseGame();
        }
        else if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            ui.hidePauseMenu();
            resumeGame();
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

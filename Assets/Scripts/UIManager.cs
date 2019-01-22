using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public bool mainMenuOn;
    public GameObject pauseMenuCanvas;
    public GameObject gameOverCanvas;

    void Start()
    {
        pauseMenuCanvas.SetActive(false);
        showMainMenu();
    }

    public void showMainMenu()
    {
        MainMenuCanvas.gameObject.SetActive(true);
        mainMenuOn = true;
    }


    public void hideMainMenu()
    {
        MainMenuCanvas.gameObject.SetActive(false);
        mainMenuOn = false;
    }

    public void showPauseMenu()
    {
        pauseMenuCanvas.SetActive(true);
    }

    public void hidePauseMenu()
    {
        pauseMenuCanvas.SetActive(false);
    }
    
    public void showGameOverMenu()
    {
        gameOverCanvas.SetActive(true);
    }

    public void hideGameOverMenu()
    {
        gameOverCanvas.SetActive(false);
    }
}

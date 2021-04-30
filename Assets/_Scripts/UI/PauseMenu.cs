using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu, settingMenu;

    //make it global
    public static bool isPause;

    void Start()
    {
        //Not imediately start
        pauseMenu.SetActive(false);
        settingMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        //Will activate when called
        pauseMenu.SetActive(true);
        //Paused
        Time.timeScale = 0f;
        isPause = true;
    }

    public void ResumeGame()
    {
        //Stop menu
        pauseMenu.SetActive(false);
        //Stop setting menu
        settingMenu.SetActive(false);
        //Resume
        Time.timeScale = 1f;
        isPause = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Settings()
    {
        pauseMenu.SetActive(false);
        settingMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

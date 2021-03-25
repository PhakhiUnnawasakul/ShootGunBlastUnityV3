using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    //make it global
    public static bool isPause;

    void Start()
    {
        //Not imediately start
        pauseMenu.SetActive(false);
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
        //Resume
        Time.timeScale = 1f;
        isPause = false;
    }
}

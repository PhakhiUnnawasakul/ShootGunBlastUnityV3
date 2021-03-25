using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    void Start()
    {
        //Not imediately start
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        
    }

    public void PauseGame()
    {
        //Will activate when called
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {

    }
}

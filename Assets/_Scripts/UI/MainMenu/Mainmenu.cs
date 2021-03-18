using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Level_0");
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}

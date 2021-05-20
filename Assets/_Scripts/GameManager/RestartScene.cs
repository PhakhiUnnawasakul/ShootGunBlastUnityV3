using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    private Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(scene.name);
        }
    }
}

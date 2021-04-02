using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int numLevelLoad;
    public string nameLevelLoad;

    public bool useIntegerToLoadLevel = false;

    void Start()
    {
         
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name == "Player")
        {
            LoadScene();
        }
    }

    void LoadScene()
    {
        if (useIntegerToLoadLevel)
        {
            //load scene with number
            SceneManager.LoadScene(numLevelLoad);
        }
        else
        {
            //load scene with name
            SceneManager.LoadScene(nameLevelLoad);
        }
    }

}

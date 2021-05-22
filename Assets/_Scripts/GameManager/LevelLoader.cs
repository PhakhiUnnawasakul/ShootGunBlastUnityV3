using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public int numLevelLoad;
    public string nameLevelLoad;

    public bool useIntegerToLoadLevel = false;

    public FadeIn fading;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name == "Player")
        {
            fading.fadeOut();

            StartCoroutine(ExecuteAfterTime(1));

            IEnumerator ExecuteAfterTime(float time)
            {
                yield return new WaitForSeconds(time);

                // Code to execute after the delay
                LoadScene();
            }
            
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

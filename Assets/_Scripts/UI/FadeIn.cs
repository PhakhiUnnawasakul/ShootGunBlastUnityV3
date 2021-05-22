using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image BlackFade;

    // Start is called before the first frame update
    void Start()
    {
        BlackFade.canvasRenderer.SetAlpha(1.0f);

        fadeIn();
    }

    void fadeIn()
    {
        BlackFade.CrossFadeAlpha(0, 2, false);
    }

    public void fadeOut()
    {
        BlackFade.CrossFadeAlpha(1, 1, false);
    }
}

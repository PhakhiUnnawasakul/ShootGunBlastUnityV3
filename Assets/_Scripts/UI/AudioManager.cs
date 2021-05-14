using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private int firstplayInt;
    public Slider backgroundSlider, soundEffectSlider;
    private float backgroundFloat, soundEffectFloat;


    void Start()
    {
        firstplayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstplayInt == 0)
        {

        }
        else
        {

        }
        
    }

}

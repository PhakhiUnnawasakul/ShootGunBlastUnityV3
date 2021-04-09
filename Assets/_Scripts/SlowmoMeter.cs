using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowmoMeter : MonoBehaviour
{
    public Slider SlowmoBar;

    private int maxBar = 100;
    private int currentBar;

    public static SlowmoMeter instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentBar = maxBar;
        SlowmoBar.maxValue = maxBar;
        SlowmoBar.value = maxBar;
    }

    public void UseSlowMo(int amount)
    {
        if(currentBar - amount >= 0)
        {
            currentBar -= amount;
            SlowmoBar.value = currentBar;
        }
        else
        {
            Debug.Log("Run out of Slowmo");
        }
    }

    
}

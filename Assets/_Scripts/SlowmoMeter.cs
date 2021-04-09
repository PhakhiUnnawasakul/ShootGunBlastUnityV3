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

    public TimeManager timeManager;

    private WaitForSeconds regenTick = new WaitForSeconds(0.01f);

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

            StartCoroutine(RegenSlowmoBar());
        }
        else
        {
            timeManager.StopSlowMotion();
            Debug.Log("Run out of Slowmo");
        }
    }

    private IEnumerator RegenSlowmoBar()
    {
        //will wait 2 seconds before continues
        yield return new WaitForSeconds(2);

        while(currentBar < maxBar)
        {
            currentBar += maxBar / 100;
            SlowmoBar.value = currentBar;
            yield return regenTick;
        }
    }
}

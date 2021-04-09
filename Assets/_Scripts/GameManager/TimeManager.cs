using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowAmount = 0.5f;
  
    void DoSlowMotion()
    {
        Time.timeScale = slowAmount;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BulletTime : MonoBehaviour
{
    public TimeManager timeManager;

    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            timeManager.DoSlowMotion();
            SlowmoMeter.instance.UseSlowMo(1);
        }
    }
}

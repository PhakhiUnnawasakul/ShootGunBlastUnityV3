using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 cameraInitialPosition;
    public float shakeMag = 0.05f, shakeTime = 0.5f;
    public Camera MainCamera;

    public void Shaking()
    {
        cameraInitialPosition = MainCamera.transform.position;
        InvokeRepeating("StartShaking", 0f, 0.0005f);
    }

    //does the shaking
    void StartShaking()
    {
        float CameraShakingOffsetX = Random.value * shakeMag * 2 - shakeMag;
        float CameraShakingOffsetY = Random.value * shakeMag * 2 - shakeMag;

    }

}

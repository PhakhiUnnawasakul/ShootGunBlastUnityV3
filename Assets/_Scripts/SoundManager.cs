using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip ShootSound;
    static AudioSource audioSrc;

    void Start()
    {
        ShootSound = Resources.Load<AudioClip>("ShootSound");
        audioSrc = GetComponent<AudioSource>();
    }


    public static void playSound()
    {
        audioSrc.PlayOneShot(ShootSound);
    }
}

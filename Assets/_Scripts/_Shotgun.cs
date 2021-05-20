using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Shotgun : MonoBehaviour
{
    public GameObject Player;

    public float offset;

    public Transform shotPoint;
    public GameObject Blast;
    private float timeBtwShots;
    public float StartTimeBtwShots;

    public AudioSource m_shootingSound;

    void Start()
    {
        m_shootingSound = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        if (!PauseMenu.isPause)
        {
            //Make gun follow mouse
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

            //Make gun flip in a correct position
            if (rotZ < -90 || rotZ > 90)
            {
                if (Player.transform.eulerAngles.y == 0)
                {
                    transform.localRotation = Quaternion.Euler(180, 0, -rotZ);
                }
                else if (Player.transform.eulerAngles.y == 180)
                {
                    transform.localRotation = Quaternion.Euler(180, 180, -rotZ);
                }
            }

            if (timeBtwShots <= 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(Blast, shotPoint.position, transform.rotation);
                    timeBtwShots = StartTimeBtwShots;

                    m_shootingSound.Play();
                }
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }




        }



    }
}

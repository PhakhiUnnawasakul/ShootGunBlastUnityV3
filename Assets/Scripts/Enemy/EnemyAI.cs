using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float Range;

    public Transform Target;

    bool Detected = false;

    Vector2 Direction;

    public GameObject Gun;

    public GameObject Bullet;

    
    
    public float FireRate;
    float nextShoot = 0;
    public Transform EnemyGunpoint;

    public float BulletForce;

    void Update()
    {
        //Direction of where the player is
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;

        //Raycasting to find player
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);

        if (rayInfo)
        {
            //if detected object with tag player, do something
            if(rayInfo.collider.gameObject.tag == "Player")
            {
                //if false, turn detection to true.s
                if(Detected == false)
                {
                    Detected = true;
                }
            }
            else
            {
                if(Detected == true)
                {
                    Detected = false;
                }
            }

        }

        //if player is detected, do something
        if (Detected)
        {
            //make gun turn
            Gun.transform.right = Direction;

            if(Time.time > nextShoot)
            {
                nextShoot = Time.time + 1 / FireRate;
                shoot();
            }
        }

    }


    void shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, EnemyGunpoint.position, transform.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * BulletForce);
    }

    //Draw sphere of the detection range
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
        
    }
}

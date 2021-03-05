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

        if (Detected)
        {
            Gun.transform.right = Direction;
        }

    }

    //Draw sphere of the detection range
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
        
    }
}

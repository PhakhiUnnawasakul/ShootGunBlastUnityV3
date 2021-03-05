using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float Range;

    public Transform Target;

    bool Detected = false;

    Vector2 Direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

    }
}

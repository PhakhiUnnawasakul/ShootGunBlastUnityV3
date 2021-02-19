using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Knockback : MonoBehaviour
{
    Rigidbody2D RB;
    public Transform GunForcePoint;
    public float GunForce = 50f;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();  
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            KnockBack();
        }
    }

    void KnockBack()
    {
        float ForceDirX = GunForcePoint.position.x;
        float ForceDirY = GunForcePoint.position.y;
        float posX = transform.position.x;
        float posY = transform.position.y;

        Vector2 Force = new Vector2(-ForceDirX + posX, -ForceDirY + posY);
        RB.velocity = new Vector2(0, 0);
        RB.AddForce(Force * GunForce, ForceMode2D.Impulse);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public int health;


    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("PlayerBlats"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        } 
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }


}

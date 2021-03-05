using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed = 2f;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.MovePosition(transform.TransformPoint(-Vector3.right * speed * Time.deltaTime));
        
    }



    void OnCollisionEnter2D(Collision2D Col)    
    {
        Destroy(this.gameObject);
        
    }
}

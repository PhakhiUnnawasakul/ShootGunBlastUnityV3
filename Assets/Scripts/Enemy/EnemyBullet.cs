using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed = 2f;
    [SerializeField] private float lifeTime = 10f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.MovePosition(transform.TransformPoint(-Vector3.right * speed * Time.deltaTime));
        lifeTime -= Time.deltaTime;
        if(lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHP targetHealth = collision.GetComponent<PlayerHP>();
        if(targetHealth != null)
        {
            targetHealth.TakeDamage(10);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)    
    {

        Destroy(this.gameObject);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Blast : MonoBehaviour
{
    public float speed;
    public float blastLife;
    public float distance;
    public LayerMask whatIsSolid;

    public int damage;

    private void Start()
    {
        Invoke("DestroyBlast", blastLife);
        
    }

    private void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy hit");

                hitInfo.collider.GetComponent<EnemyAI>().TakeDamage(damage);
            }
            
        }
    }

    void DestroyBlast()
    {
        Destroy(gameObject);
    }
}

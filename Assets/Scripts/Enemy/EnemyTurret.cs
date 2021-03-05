using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    [SerializeField] private float scanRadius = 3f;
    [SerializeField] private LayerMask layers;
    private Collider2D target;

    private void Update()
    {
        CheckEnvironment();
        LookAtTarget();
    }

    void CheckEnvironment()
    {
        target = Physics2D.OverlapCircle(transform.position, scanRadius, layers);
        //if (target != null) Debug.Log(target.gameObject.name);
    }

    void LookAtTarget()
    {
        if(target != null)
        {
            Vector2 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, scanRadius);
    }

}

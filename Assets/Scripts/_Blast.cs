using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Blast : MonoBehaviour
{
    public float blastLife;

    private void Start()
    {
        Invoke("DestroyBlast", blastLife);
        
    }

    void DestroyBlast()
    {
        Destroy(gameObject);
    }
}

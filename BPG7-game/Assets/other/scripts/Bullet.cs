using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.layer.ToString() == "grapable")
        {
            Destroy(gameObject);
        }
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        
    }
}

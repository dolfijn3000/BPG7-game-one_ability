using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float recoil;
    protected Rigidbody2D rb;
    protected Camera mainCam;
    void Awake()
    {
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }
    protected void look(Vector2 position)
    {
        transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, position - (Vector2)transform.position));
    }
    protected void shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        rb.AddForce(-transform.up * recoil * 10, ForceMode2D.Force);
    }
}

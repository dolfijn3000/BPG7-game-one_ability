﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float collitionRaduice;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * bulletSpeed * Time.deltaTime * 60;
        var enemy = Physics2D.OverlapCircle(transform.position, collitionRaduice, enemyLayer);
        if (enemy != null)
        {
            enemy.SendMessage("TakeDamage");
            this.destroy();
        }
    }
    private void destroy()
    {
        Destroy(gameObject);
    }
}

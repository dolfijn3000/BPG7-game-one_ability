using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Agent
{
    [SerializeField] bool pc;
    [SerializeField] float decceloration;
    [SerializeField] public List<Transform> gunPoints;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    float startTime;
    float startTimeLastBullet;
    bool block = false;
    bool lastBulletBlock = false;

    // Update is called once per frame
    void Update()
    {
        if (!GameState.IsRunning) return;
        float timePressed = Time.time - startTime;
        if (pc)
        {
            look(mainCam.ScreenToWorldPoint(Input.mousePosition));
        }
        if (Input.GetMouseButtonDown(0) )
        {
            look(mainCam.ScreenToWorldPoint(Input.mousePosition));
            ShootOne(gunPoints);
        }
        if (Input.GetMouseButtonDown(1))
        {
            if(block == false)
            {
                startTime = Time.time;
                block = true;
            }                       
        }
        if(Input.GetMouseButtonUp(1))
        {
            block = false;
        }
        if (timePressed > 1 && block == true)
        {
            if (lastBulletBlock == false)
            {
                startTimeLastBullet = Time.time;
                lastBulletBlock = true;
            }
            float timeSinceLastBullet = Time.time - startTimeLastBullet;

            if (timeSinceLastBullet > 0.5)
            {
                startTimeLastBullet = Time.time;
                look(mainCam.ScreenToWorldPoint(Input.mousePosition));
                Shoot(gunPoints);
                lastBulletBlock = true;
            }
        }
        if (Input.touchCount > 0)
        {
            look(Input.touches[0].position);
            Debug.Log(Input.touches[0].position);
            Shoot(gunPoints);
        }
        rb.velocity += -rb.velocity * decceloration * Time.deltaTime;
    }
    public override void Die()
    {
        base.Die();
        Destroy(this.gameObject);
        GameState.IsRunning = false;
        FindObjectOfType<GameManager>().RestartGame();
    }
}

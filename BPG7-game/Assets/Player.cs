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

    // Update is called once per frame
    void Update()
    {
        if(!GameState.IsRunning) return;

        if (pc)
        {
            look(mainCam.ScreenToWorldPoint(Input.mousePosition));
        }
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            look(mainCam.ScreenToWorldPoint(Input.mousePosition));
            foreach (var gun in gunPoints)
            {
                Shoot(gun);
            }

        }
        if (Input.touchCount > 0)
        {
            look(Input.touches[0].position);
            Debug.Log(Input.touches[0].position);
            foreach (var gun in gunPoints)
            {
                Shoot(gun);
            }
        }
        rb.velocity += -rb.velocity * decceloration * Time.deltaTime;
    }
    private void destroy()
    {
        Destroy(this.gameObject);
        GameState.IsRunning = false;
        FindObjectOfType<GameManager>().RestartGame();
    }
}

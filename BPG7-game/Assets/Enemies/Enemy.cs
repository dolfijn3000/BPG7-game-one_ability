using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Agent
{
    [SerializeField] float defaultCooldown;
    private float cooldown;
    private Transform player;
    private Vector2 destination;
    private Vector2 destinationRange = new Vector2(15, 7);
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameState.IsRunning) return;
        
        cooldown -= Time.deltaTime;
        look(player.position);
        if (cooldown < 0)
        {
            look(player.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0));
            Shoot();
            cooldown = defaultCooldown;
        }
        look(player.position);

        rb.velocity = (destination - (Vector2)transform.position).normalized * Time.deltaTime * speed * 60;
        if ((destination - (Vector2)transform.position).magnitude < 1)
        {
            destination = new Vector2(
                Random.Range(-destinationRange.x, destinationRange.x),
                Random.Range(-destinationRange.y, destinationRange.y)
                );
        }
    }
    private void destroy()
    {
        Destroy(this.gameObject);
    }
}

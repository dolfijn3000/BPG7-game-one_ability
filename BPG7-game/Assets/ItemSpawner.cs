using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    SpriteRenderer renderer;
    bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        StartCoroutine(routine());
        
    }

    IEnumerator routine()
    {
        bool running = true;
        while (running)
        {
            
            if (active == false)
            {
                active = true;
                renderer.color = Color.red;
                yield return new WaitForSeconds(Random.Range(0,10));
            }
            yield return null;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (active)
        {
            if (collision.gameObject.name == "Player")
            {
                int BulletPointsActive = collision.gameObject.GetComponent<Player>().gunPoints.Count;
                int gunToFind = BulletPointsActive + 1;
                Debug.Log("Gunpoint" + gunToFind);
                Transform gun = collision.transform.Find("Gunpoint" + gunToFind);
                Debug.Log(gun.position);
                collision.gameObject.GetComponent<Player>().gunPoints.Add(gun);
                renderer.color = Color.white;
                active = false;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
}

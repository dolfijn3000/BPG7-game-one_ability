using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        StartCoroutine(routine());
        
    }

    IEnumerator routine()
    {
        //renderer.color = Color.red;
        yield return new WaitForSeconds(Random.Range(0,10));
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name == "Player")
        {
            int BulletPointsActive = collision.gameObject.GetComponent<Player>().gunPoints.Count;
            collision.gameObject.GetComponent<Player>().gunPoints.Add(gameObject.transform.GetChild(BulletPointsActive + 1));
            renderer.color = Color.red;
        }
        renderer.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
    }
}

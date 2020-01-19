using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{

    public static bool NewCheckpointSpawnable = true;
    public GameObject checkPointPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(routine());
    }

    IEnumerator routine()
    {
        bool running = true;
        while (running)
        {

            if(NewCheckpointSpawnable)
            {
                Instantiate(checkPointPrefab, new Vector2(Random.Range(-18,18), Random.Range(-8,8)) , Quaternion.identity);
                NewCheckpointSpawnable = false;
            }

            yield return new WaitForSeconds(2);

        }

           
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

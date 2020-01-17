using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] PropabilityTable SpawnableEnemies;
    [SerializeField] Vector2[] spawnPositions;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            if (GameState.IsRunning) spawnEnemy();
            float cooldown = .8f;
            cooldown += (100 - Time.time) > 0 ? (100 - Time.time) / 20 : 0;
            yield return new WaitForSeconds(cooldown);
        }
    }
    private void spawnEnemy()
    {
        Vector2 spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];

        Instantiate(SpawnableEnemies.GetRandomItem(), spawnPosition, Quaternion.identity);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        foreach (var p in spawnPositions)
        {
            Gizmos.DrawLine(Vector3.zero, p);
        }
    }
}

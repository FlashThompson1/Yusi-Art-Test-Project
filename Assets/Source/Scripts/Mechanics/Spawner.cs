using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; 
    [SerializeField] private Transform groundPlane;
    [SerializeField] private float spawnRadius;
    [SerializeField] private float spawnInterval;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            
            Vector3 randomPosition = groundPlane.position + Random.insideUnitSphere * spawnRadius;
            randomPosition.y = groundPlane.position.y;

           
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

            
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
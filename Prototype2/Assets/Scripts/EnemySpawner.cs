using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private float minCoordinatesToSpawn;
    [SerializeField] private float maxCoordinatesToSpawn;
    [SerializeField] private bool verticalSpawning;
    [SerializeField] private float spawnEvery = 4f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 2, spawnEvery);
    }

    private void SpawnEnemy()
    {
        var spawnPosition = verticalSpawning
            ? new Vector3(Random.Range(minCoordinatesToSpawn, maxCoordinatesToSpawn), 0f, transform.position.z)
            : new Vector3(transform.position.x, 0f, Random.Range(minCoordinatesToSpawn, maxCoordinatesToSpawn));
        
        var animalType = Random.Range(0, enemies.Count);
        var enemy = enemies[animalType];

        var rotation = enemy.transform.rotation;
        if(!verticalSpawning && transform.position.x < 0)
            rotation.SetLookRotation(Vector3.right, Vector3.up);
        if(!verticalSpawning && transform.position.x > 0)
            rotation.SetLookRotation(Vector3.left, Vector3.up);
        
        Instantiate(enemy, spawnPosition, rotation);
    }
}

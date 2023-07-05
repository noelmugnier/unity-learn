using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    private float spawnEvery = 1.5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 2, spawnEvery);
    }

    private void SpawnEnemy()
    {
        var spawnPosition = new Vector3(Random.Range(-14, 14), 0f, transform.position.z);
        var animalType = Random.Range(0, enemies.Count);

        var enemy = enemies[animalType];
        Instantiate(enemy, spawnPosition, enemy.transform.rotation);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemyVehicle> vehicles = new ();
    private System.Random _random = new System.Random();
    
    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, 3);
    }

    private void Spawn()
    {
        var enemyType = 0;
        var randomNumber = _random.Next(0, 1000);
        
        if(randomNumber % 2 == 0)
            enemyType = 1;

        if (randomNumber % 3 == 0)
            enemyType = 2;
        
        if (randomNumber % 7 == 0)
            enemyType = 3;
                
        Instantiate(vehicles[enemyType], transform);
    }
}

using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabsToSpawn;
    [SerializeField] private Vector3 _spawnPosition = new (25f, 0f, 0f);

    private void Start()
    {
        Invoke(nameof(SpawnPrefab), Random.Range(3, 5));
    }

    private void SpawnPrefab()
    {
        if (GameManager.Instance.IsGameOver)
            return;

        var prefabToSpawn = _prefabsToSpawn[Random.Range(0, _prefabsToSpawn.Length)];
        Instantiate(prefabToSpawn, _spawnPosition, prefabToSpawn.transform.rotation);
        Invoke(nameof(SpawnPrefab), Random.Range(1, 3));
    }
}
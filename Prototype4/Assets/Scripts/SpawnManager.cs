using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    private float _range = 9f;

    public void Start()
    {
        Instantiate(_enemyPrefab, GenerateSpawnPosition(), _enemyPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        return new Vector3(Random.Range(-_range, _range), 0f, Random.Range(-_range, _range));
    }
}

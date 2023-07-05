using UnityEngine;

public class EnemyVehicle : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(Delete), 45);
    }

    private void Delete()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position -= Vector3.forward * Time.deltaTime * 30f;
    }
}

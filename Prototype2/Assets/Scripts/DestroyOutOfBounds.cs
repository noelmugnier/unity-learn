using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float _topBound = 30f;
    private float _lowerBound = -10f;

    private void Update()
    {
        if (transform.position.z > _topBound)
            Destroy(gameObject);

        if (transform.position.z < _lowerBound)
        {
            Debug.Log("Game over !");
            Destroy(gameObject);
        }
    }
}

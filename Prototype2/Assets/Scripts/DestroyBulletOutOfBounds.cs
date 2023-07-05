using UnityEngine;

public class DestroyBulletOutOfBounds : MonoBehaviour
{
    private float _topBound = 30f;

    private void Update()
    {
        if (transform.position.z < _topBound)
            return;

        Destroy(gameObject);
    }
}
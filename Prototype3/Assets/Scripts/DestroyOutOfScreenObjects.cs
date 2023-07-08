using UnityEngine;

public class DestroyOutOfScreenObjects : MonoBehaviour
{
    private void Update()
    {
        if(transform.position.x <= -10)
            Destroy(gameObject);
    }
}
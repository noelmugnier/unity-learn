using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    
    private void Update()
    {
        transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
    }
}

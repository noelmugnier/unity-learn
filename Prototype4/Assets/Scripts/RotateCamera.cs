using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 45;

    private void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * _rotationSpeed * Time.deltaTime * -1);
    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _focalPoint;
    
    private Rigidbody _rigidBody;
    private float _speed = 5f;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var verticalInput = Input.GetAxis("Vertical");
        _rigidBody.AddForce(_focalPoint.transform.forward * (_speed * verticalInput));
    }
}

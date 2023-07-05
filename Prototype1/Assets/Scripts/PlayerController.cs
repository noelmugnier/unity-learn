using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private KeyCode accelerateKey = KeyCode.Z;
    [SerializeField] private KeyCode breakKey = KeyCode.S;
    [SerializeField] private KeyCode turnLeftKey = KeyCode.Q;
    [SerializeField] private KeyCode turnRightKey = KeyCode.D;
    [SerializeField] private KeyCode boostKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;
    
    private Rigidbody _rigidBody;
    private float _vehicleSpeed = 20.0f;
    private float _rotationSpeed = 45.0f;

    private void Start()
    {
        _rigidBody = gameObject.GetComponentInChildren<Rigidbody>();
    }

    void Update()
    {
        var boost = Input.GetKey(boostKey);
        var jump = Input.GetKey(jumpKey);
        var moveHorizontal = Input.GetKey(turnRightKey) || Input.GetKey(turnLeftKey);
        var moveVertical = Input.GetKey(accelerateKey) || Input.GetKey(breakKey);
        var moveInput = new Vector3(moveHorizontal ? (Input.GetKey(turnLeftKey) ? -1 : 1) : 0f, 0f, moveVertical ? (Input.GetKey(breakKey) ? -1 : 1) : 0f);
        
        var speedMultiplicator = boost ? 1.5f : 1f;
 
        transform.Translate(_rigidBody.transform.forward * (Time.deltaTime * _vehicleSpeed * speedMultiplicator * moveInput.z));
        transform.Rotate(_rigidBody.transform.up * (Time.deltaTime * _rotationSpeed * speedMultiplicator  * moveInput.x));

        if (jump)
            _rigidBody.AddForce(new Vector3(0f, 500000f, moveInput.z));
    }
}

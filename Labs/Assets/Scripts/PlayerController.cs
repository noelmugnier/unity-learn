using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] private float _zBound = 10f;
    
    private PlayerInput _input;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _input = new PlayerInput();
    }

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        Move();
        ConstrainPosition();
    }

    private void ConstrainPosition()
    {
        if (transform.position.z > _zBound)
            transform.position = new(transform.position.x, transform.position.y, _zBound);

        if (transform.position.z < -_zBound)
            transform.position = new(transform.position.x, transform.position.y, -_zBound);
    }

    private void Move()
    {
        var moveDirection = _input.Player.Move.ReadValue<Vector2>();
        _rigidBody.AddForce(_movementSpeed * new Vector3(moveDirection.x, 0f, moveDirection.y));
    }
}

using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 25f;
    private PlayerInputActions _actions;
    [SerializeField] private Transform projectile;

    private void Awake()
    {
        _actions = new PlayerInputActions();
        _actions.Player.Shoot.performed += Shoot;
    }

    private void Shoot(InputAction.CallbackContext obj)
    {
        Instantiate(projectile, transform.position, projectile.rotation);
    }

    private void OnEnable()
    {
        _actions.Enable();
    }

    private void Update()
    {
        var direction = _actions.Player.Move.ReadValue<Vector2>();
        direction = ConstraintHorizontalMovement(direction);
        direction = ConstraintVerticalMovement(direction);

        var movementDirection = new Vector3(direction.x, 0f, direction.y);
        transform.Translate(movementDirection * (Time.deltaTime * movementSpeed));
    }

    private Vector2 ConstraintVerticalMovement(Vector2 direction)
    {
        direction.y = transform.position.z switch
        {
            < 0 when direction.y < 0 => 0,
            > 10 when direction.y > 0 => 0,
            _ => direction.y
        };

        return direction;
    }

    private Vector2 ConstraintHorizontalMovement(Vector2 direction)
    {
        direction.x = transform.position.x switch
        {
            < -15 when direction.x < 0 => 0,
            > 15 when direction.x > 0 => 0,
            _ => direction.x
        };

        return direction;
    }
}
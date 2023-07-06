using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 25f;
    [SerializeField] private Transform _projectile;
    private PlayerInputActions _actions;

    private void Awake()
    {
        _actions = new PlayerInputActions();
        _actions.Player.Shoot.performed += Shoot;
    }

    private void Shoot(InputAction.CallbackContext obj)
    {
        Instantiate(_projectile, transform.position, _projectile.rotation);
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
        transform.Translate(movementDirection * (Time.deltaTime * _movementSpeed));
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

    public void CollideEnemy()
    {
        GameManager.Instance.DecreaseLives();
    }
}
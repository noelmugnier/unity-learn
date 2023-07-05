using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 20f;
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
        var x = direction.x;
        if (transform.position.x < -15 && x < 0)
            return;
        
        if (transform.position.x > 15 && x > 0)
            return;
        
        var y = direction.y;
        if (transform.position.z < 0 && y < 0)
            return;
        
        if (transform.position.z > 10 && y > 0)
            return;
        
        var movementDirection = new Vector3(x, 0f, y);
        transform.Translate(movementDirection * (Time.deltaTime * movementSpeed));
    }
}

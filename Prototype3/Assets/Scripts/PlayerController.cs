using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 200f;
    [SerializeField] private float _gravityModifier = 1f;
    [SerializeField] private ParticleSystem _collideParticleEffect;
    [SerializeField] private ParticleSystem _runningParticleEffect;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _crashSound;
    private AudioSource _audioSource;

    private Rigidbody _rigidBody;
    private PlayerInput _actions;
    private bool _isOnGround = true;
    private Animator _animator;
    private bool _isDoubleJumping;

    private void Awake()
    {
        _actions = new PlayerInput();
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        Physics.gravity *= _gravityModifier;
    }

    private void OnEnable()
    {
        _actions.Enable();
        _actions.Player.Jump.performed += Jump;
    }

    private void OnDisable()
    {
        _actions.Disable();
        _actions.Player.Jump.performed -= Jump;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (GameManager.Instance.IsGameOver)
            return;

        if (other.gameObject.CompareTag("Ground"))
            TouchGround();

        if (other.gameObject.CompareTag("Obstacle"))
            CollideObstacle();
    }

    private void TouchGround()
    {
        _isOnGround = true;
        _isDoubleJumping = false;
        _runningParticleEffect.Play();
    }

    private void CollideObstacle()
    {
        _collideParticleEffect.Play();
        _runningParticleEffect.Stop();
        _audioSource.PlayOneShot(_crashSound, 1f);
        Die();
    }

    private void Die()
    {
        _animator.SetBool("Death_b", true);
        _animator.SetInteger("DeathType_int", 1);
        GameManager.Instance.SetGameOver();
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        if (_isDoubleJumping || GameManager.Instance.IsGameOver)
            return;

        if (!_isOnGround)
            _isDoubleJumping = true;

        MakeJump();
    }

    private void MakeJump()
    {
        _runningParticleEffect.Stop();
        _isOnGround = false;
        _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _animator.SetTrigger("Jump_trig");
        _audioSource.PlayOneShot(_jumpSound, 1f);
    }
}
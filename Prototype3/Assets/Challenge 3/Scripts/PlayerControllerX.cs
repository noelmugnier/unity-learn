using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver { get; private set; }

    [SerializeField] private float _forceImpulse = 100f;
    [SerializeField] private float _gravityModifier = 5f;
    private Rigidbody _rigidBody;
    private AudioSource _audioSource;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    public AudioClip moneySound;
    public AudioClip explodeSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= _gravityModifier;
        _audioSource = GetComponent<AudioSource>();
        _rigidBody = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        _rigidBody.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 15)
        {
            transform.position = new Vector3(transform.position.x, 15, 0f);
            _rigidBody.AddForce(Vector3.down * 5, ForceMode.Impulse);
        }

        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            _rigidBody.AddForce(Vector3.up * (_forceImpulse * Time.deltaTime), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            _audioSource.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            _audioSource.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveLeftX : MonoBehaviour
{
    private float _speed = 20;
    private PlayerControllerX _playerController;
    private const float _leftBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        // If game is not over, move to the left
        if (!_playerController.gameOver)
            transform.Translate(Vector3.left * (_speed * Time.deltaTime), Space.World);

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x < _leftBound && !gameObject.CompareTag("Background"))
            Destroy(gameObject);
    }
}

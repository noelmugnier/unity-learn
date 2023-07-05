using System;
using UnityEngine;

public class DestroyEnemyOutOfBounds : MonoBehaviour
{
    private float _lowerBound = -10f;
    private float _leftBound = -25f;
    private float _rightBound = 25f;

    private void Update()
    {
        if (transform.position.z < _lowerBound
            || transform.position.x < _leftBound
            || transform.position.x > _rightBound)
        {
            GameManager.Instance.SetGameOver();
            Destroy(gameObject);
        }
    }
}

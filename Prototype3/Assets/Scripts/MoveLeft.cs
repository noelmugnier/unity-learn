using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 30f;

    void Update()
    {
        if (GameManager.Instance.IsGameOver)
            return;
        
        transform.Translate(Vector3.left * (Time.deltaTime * _moveSpeed * GameManager.Instance.SpeedMultiplier));
    }
}

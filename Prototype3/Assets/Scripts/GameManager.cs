using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (IsGameOver)
            return;

        Score += Time.deltaTime * SpeedMultiplier * 10;
        Debug.Log(Score);
    }

    public float Score { get; private set; }
    public static GameManager Instance => _instance;
    public bool IsGameOver { get; private set; }
    public float SpeedMultiplier => Input.GetKey(KeyCode.LeftShift) ? 1.5f : 1f;
    
    public void SetGameOver()
    {
        IsGameOver = true;
        Debug.Log("Game over");
    }
}
using UnityEngine;

public class GameManager
{
    private static GameManager _instance;
    private bool _isGameOver;
    private int _score;

    private GameManager()
    {
    }

    public static GameManager Instance
    {
        get
        {
            _instance ??= new GameManager();
            return _instance;
        }
    }

    public bool IsGameOver => _isGameOver;
    public int CurrentScore => _score;

    public void SetGameOver()
    {
        _isGameOver = true;
        _score = 0;
        Debug.Log("Game Over");
    }

    public void IncreaseScore()
    {
        if (_isGameOver)
            return;
        
        _score++;
        Debug.Log($"Score increase to {_score}");
    }

    public void DecreaseScore()
    {
        if (_isGameOver)
            return;
        
        _score--;
        Debug.Log($"Score decreased to {_score}");
        if(_score <= 0)
            SetGameOver();
    }
}
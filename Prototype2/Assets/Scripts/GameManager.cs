using UnityEngine;

public class GameManager
{
    private static GameManager _instance;
    private bool _isGameOver = false;
    private int _score = 0;
    private int _livesCount = 3;

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

    public void SetGameOver()
    {
        _isGameOver = true;
        _livesCount = 0;
        Debug.Log("Game Over");
    }

    public void IncreaseScore()
    {
        if (_isGameOver)
            return;
        
        _score++;
    }

    public void DecreaseLives()
    {
        if (_isGameOver)
            return;
        
        _livesCount--;
        if(_livesCount <= 0)
            SetGameOver();
    }
}
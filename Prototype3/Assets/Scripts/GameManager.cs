using UnityEngine;

public class GameManager
{
    private static GameManager _instance;

    private GameManager()
    {
    }

    public static GameManager Instance => _instance ??= new GameManager();
    public bool IsGameOver { get; private set; }
    
    public void SetGameOver()
    {
        IsGameOver = true;
        Debug.Log("Game over");
    }
}
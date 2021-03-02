using UnityEngine;

public class GameManager
{
    public enum GameState { MENU, GAME, PAUSE, ENDGAME };
    public GameState gameState { get; private set; }
    public GameState oldGameState { get; private set; }
    public int lives;
    public int points;
    public int level;
    private static GameManager _instance;

    public static GameManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }

    private GameManager()
    {
        level = 1;
        lives = 3;
        points = 0;
        gameState = GameState.MENU;
    }


    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState)
    {
        oldGameState = gameState;
        if (nextState == GameState.GAME && oldGameState != GameState.PAUSE)
        {
            Reset();
        }
        gameState = nextState;
        changeStateDelegate();
    }

    private void Reset()
    {
        level = 1;
        lives = 3;
        points = 0;
    }
}

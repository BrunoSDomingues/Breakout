using UnityEngine;

public class GameManager
{
    public enum GameState { MENU, GAME, PAUSE, ENDGAME };
    public GameState gameState { get; private set; }
    public int lives;
    public int points;
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
        lives = 3;
        points = 0;
        gameState = GameState.MENU;
    }


    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState)
    {
        gameState = nextState;
        Debug.Log("state = " + nextState);
        changeStateDelegate();
    }

    private void Reset()
    {
        lives = 3;
        points = 0;
    }
}

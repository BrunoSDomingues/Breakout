using UnityEngine;

public class UI_StartGame : MonoBehaviour
{
    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    public void StartGame()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}

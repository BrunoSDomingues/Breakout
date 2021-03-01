using UnityEngine;
using UnityEngine.UI;

public class UI_GameOver : MonoBehaviour
{
    public Text message;

    GameManager gm;
    private void OnEnable()
    {
        gm = GameManager.GetInstance();

        if (gm.lives > 0)
        {
            message.text = "You win!";
        }
        else
        {
            message.text = "Game Over";
        }
    }

    public void NewGame()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}

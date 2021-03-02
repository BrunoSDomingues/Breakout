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
            message.text = "ERROR: You're not supposed to see this text!";
        }
        else
        {
            message.text = "You scored " + gm.points + " points!";
        }
    }

    public void NewGame()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}

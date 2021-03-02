using UnityEngine;
using UnityEngine.UI;

public class UI_GameOver : MonoBehaviour
{
    public Text message;

    GameManager gm;
    private void OnEnable()
    {
        gm = GameManager.GetInstance();
        message.text = "You scored " + gm.points + " points!";
    }

    public void NewGame()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GamePaused : MonoBehaviour
{
    GameManager gm;

    private void OnEnable()
    {
        gm = GameManager.GetInstance();
    }

    public void ResumeGame()
    {
        gm.ChangeState(GameManager.GameState.GAME);
    }

    public void ExitGame()
    {
        gm.ChangeState(GameManager.GameState.MENU);
    }
}

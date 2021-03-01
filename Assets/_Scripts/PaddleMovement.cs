using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float paddleSpeed = 15;
    public GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        float inputX = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(inputX, 0, 0) * Time.deltaTime * paddleSpeed);

        if (Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }
    }
}

using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float paddleSpeed = 10;
    public GameManager gm;
    int oldX, inputX;
    bool canMove;

    void Start()
    {
        oldX = 0;
        canMove = true;
        gm = GameManager.GetInstance();
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(0, -5.0f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Sides")
        {
            oldX = inputX;
            canMove = false;
            paddleSpeed = 0;
        }
    }

    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputX = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            inputX = 1;
        }
        else
        {
            inputX = 0;
        }

        if (canMove) transform.Translate(new Vector3(inputX, 0, 0) * Time.deltaTime * paddleSpeed);
        else if (oldX != inputX && inputX != 0)
        {
            canMove = true;
            paddleSpeed = 10;
        }

        if (Input.GetKeyDown(KeyCode.P) && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }
    }
}

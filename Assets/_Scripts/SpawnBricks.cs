using UnityEngine;

public class SpawnBricks : MonoBehaviour
{
    public GameObject Brick;
    public BallMovement ballMovement;
    public PaddleMovement paddleMovement;
    GameManager gm;

    void Start()
    {
        ballMovement = FindObjectOfType<BallMovement>();
        paddleMovement = FindObjectOfType<PaddleMovement>();
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Spawn;
        Spawn();
    }

    void Spawn()
    {
        if (gm.gameState == GameManager.GameState.GAME && gm.oldGameState != GameManager.GameState.PAUSE)
        {
            foreach (Transform child in transform) GameObject.Destroy(child.gameObject);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Vector3 position = new Vector3(-6.6f + 1.7f * i, 4.7f - 0.7f * j);
                    Instantiate(Brick, position, Quaternion.identity, transform);
                }
            }
        }
    }

    void Update()
    {
        if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.level++;
            if (gm.level % 2 == 1 && gm.level > 1) gm.lives++;
            paddleMovement.ResetPosition();
            ballMovement.ResetPosition();
            Spawn();
        }
    }
}

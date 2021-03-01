using UnityEngine;

public class SpawnBricks : MonoBehaviour
{
    public GameObject Brick;
    GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Spawn;
        Spawn();
    }

    void Spawn()
    {
        if (gm.gameState == GameManager.GameState.GAME)
        {
            foreach (Transform child in transform) GameObject.Destroy(child.gameObject);
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    Vector3 position = new Vector3(-3.5f + 1.4f * i, 5.3f - 0.45f * j);
                    Instantiate(Brick, position, Quaternion.identity, transform);
                }
            }
        }
    }

    void Update()
    {
        if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
    }
}

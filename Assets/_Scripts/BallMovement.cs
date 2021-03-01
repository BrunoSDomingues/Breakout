using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallMovement : MonoBehaviour
{

    public float ballSpeed = 4.0f;

    private Vector3 direction, startPosition;
    public GameManager gm;
    float dirX, dirY;

    // Start is called before the first frame update
    void Start()

    {
        transform.position = new Vector3(0, -4.0f);
        startPosition = transform.position;
        dirX = Random.Range(-5.0f, 5.0f);
        dirY = Random.Range(1.0f, 5.0f);

        direction = new Vector3(dirX, dirY).normalized;

        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;
        transform.Translate(direction * Time.deltaTime * ballSpeed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Paddle":
                dirX = Random.Range(-5.0f, 5.0f);
                dirY = Random.Range(1.0f, 5.0f);
                direction = new Vector3(dirX, dirY).normalized;
                break;

            case "Brick":
                direction = new Vector3(direction.x, -direction.y);
                gm.points += 10;
                break;

            case "Sides":
                direction = new Vector3(-direction.x, direction.y);
                break;

            case "Top":
                direction = new Vector3(direction.x, -direction.y);
                break;

            case "Bottom":
                Respawn();
                break;
        }
    }

    public void Respawn()
    {
        gm.lives--;
        if (gm.lives <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
        transform.position = startPosition;
        direction = Vector3.zero;
        StartCoroutine(WaitKeyPress());
    }

    IEnumerator WaitKeyPress()
    {
        while (!Input.GetKey("space"))
        {
            yield return null;
            Debug.Log("EEE");
        }

        dirX = Random.Range(-5.0f, 5.0f);
        dirY = Random.Range(1.0f, 5.0f);
        direction = new Vector3(dirX, dirY).normalized;
    }
}

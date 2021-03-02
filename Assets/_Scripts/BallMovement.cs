using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallMovement : MonoBehaviour
{

    private Vector3 direction, startPosition;
    public GameManager gm;
    public PaddleMovement paddleMovement;
    public float ballSpeed;
    public GameObject hitSound, blockSound, deathSound;
    float dirX, dirY;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -4.5f);
        startPosition = transform.position;
        StartCoroutine(WaitKeyPress());

        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameState == GameManager.GameState.MENU) ResetPosition();
        if (gm.gameState != GameManager.GameState.GAME) return;
        ballSpeed = ((gm.level - 1) * 1.2f) + 5.0f;
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
                hitSound.GetComponent<AudioSource>().Play();
                break;

            case "Brick":
                direction = new Vector3(direction.x, -direction.y);
                gm.points += gm.level * 10;
                blockSound.GetComponent<AudioSource>().Play();
                break;

            case "Sides":
                direction = new Vector3(-direction.x, direction.y);
                hitSound.GetComponent<AudioSource>().Play();
                break;

            case "Top":
                direction = new Vector3(direction.x, -direction.y);
                hitSound.GetComponent<AudioSource>().Play();
                break;

            case "Bottom":
                deathSound.GetComponent<AudioSource>().Play();
                Respawn();
                break;
        }
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
        direction = Vector3.zero;
        StartCoroutine(WaitKeyPress());
    }

    public void Respawn()
    {
        gm.lives--;
        if (gm.lives <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }

        ResetPosition();
    }

    IEnumerator WaitKeyPress()
    {
        while (!Input.GetKey("space"))
        {
            yield return null;
        }

        dirX = Random.Range(-5.0f, 5.0f);
        dirY = Random.Range(1.0f, 5.0f);
        direction = new Vector3(dirX, dirY).normalized;
    }
}

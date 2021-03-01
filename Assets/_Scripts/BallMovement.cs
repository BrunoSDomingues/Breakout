using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public float ballSpeed = 4.0f;

    private Vector3 direction;
    float dirX, dirY;

    // Start is called before the first frame update
    void Start()

    {
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
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
        transform.position = new Vector3(0, -4.0f);
        dirX = Random.Range(-5.0f, 5.0f);
        dirY = Random.Range(1.0f, 5.0f);

        direction = new Vector3(dirX, dirY).normalized;
    }
}

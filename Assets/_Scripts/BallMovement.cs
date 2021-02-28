using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    [Range(1, 15)]
    public float ballSpeed = 5.0f;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()

    {
        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(1.0f, 5.0f);

        direction = new Vector3(dirX, dirY).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * ballSpeed);

        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);

        if (viewportPosition.x < 0 || viewportPosition.x > 1)
        {
            direction = new Vector3(-direction.x, direction.y);
        }
        if (viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            direction = new Vector3(direction.x, -direction.y);
        }

    }
}

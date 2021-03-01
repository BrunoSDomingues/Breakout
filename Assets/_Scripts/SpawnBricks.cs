using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBricks : MonoBehaviour
{
    public GameObject Brick;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                Vector3 position = new Vector3(-3.5f + 1.4f * i, 5.3f - 0.45f * j);
                Instantiate(Brick, position, Quaternion.identity, transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using UnityEngine;
using UnityEngine.UI;

public class UI_Lives : MonoBehaviour
{
    Text textComp;
    GameManager gm;
    void Start()
    {
        textComp = GetComponent<Text>();
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        textComp.text = $"Lives: {gm.lives}";
    }
}

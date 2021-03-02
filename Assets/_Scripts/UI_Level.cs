using UnityEngine;
using UnityEngine.UI;

public class UI_Level : MonoBehaviour
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
        textComp.text = $"LEVEL {gm.level}";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreDisplay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameData.GlobalScore < 0)
        {
            GameData.GlobalScore = 0f;
        }
        else
        {
            string toText = $"Score: {GameData.GlobalScore.ToString("0")}";
            scoreDisplay.text = toText;
        }
    }
}

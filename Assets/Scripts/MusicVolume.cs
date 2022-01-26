using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    [SerializeField] private Slider mySlider;
    [SerializeField] private Text myText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mySlider.onValueChanged.AddListener((v) =>
        {
            myText.text = $"Music Volume: {v.ToString("0.0")}";
        });
    }
}

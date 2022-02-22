using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsScreen : MonoBehaviour
{

    void Start()
    {
        GameObject.Find("MusicSlider").GetComponent<Slider>().value = GameSettings.GetVolume();
    }

    void Update()
    {
    }

    public static void UpdateVolume(float vol)
    {
        GameSettings.SetVolume(vol);
        GameObject.Find("Music").GetComponent<Text>().text = "Music Volume: " + vol.ToString("0.0");
        GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = vol / 10;
    }

}

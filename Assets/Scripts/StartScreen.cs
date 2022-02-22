using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{

    public static void Quit()
    {
        Application.Quit();
    }

    public static void Play()
    {
        SceneManager.LoadScene("Scenes/Transition1");
    }

    public static void Stats()
    {
        SceneManager.LoadScene("Scenes/StatsScreen");
    }

    public static void Options()
    {
        SceneManager.LoadScene("Scenes/OptionsMenu");
    }
}

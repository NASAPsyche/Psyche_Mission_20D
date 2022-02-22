using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class StartScreen : MonoBehaviour
{

    void Start()
    {
        if(GameSettings.questionList.Count == 0)
        {
            ReadFromCSV();
        }
    }

    void ReadFromCSV()
    {
        string folderPath = Application.dataPath;
        StreamReader reader = new StreamReader($"{folderPath}/WordBank.csv");
        bool EOF = false;
        while (!EOF)
        {
            string line = reader.ReadLine();
            if (line == null)
            {
                EOF = true;
                break;
            }
            GameSettings.questionList.Add(line);
        }
    }

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

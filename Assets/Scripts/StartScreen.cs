using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class StartScreen : MonoBehaviour
{

    void Start()
    {
        ReadFromJSON();
    }

    void ReadFromJSON()
    {
        GameSettings.questionList = JsonUtility.FromJson<QuestionList>(AnswerData.answerData);
    }

    public static void Play()
    {
        SceneManager.LoadScene("Scenes/Transition1");
    }

    public static void Options()
    {
        SceneManager.LoadScene("Scenes/OptionsMenu");
    }
}

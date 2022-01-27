using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script is used to score all global datas such as total score, time.
 */
public class GameData : MonoBehaviour
{
    public static float GlobalScore = 0f;
    public static float GlobalTime = 0f;
    public static int MazeQuestionNum = 0; //To track how many questions have been asked in maze level

    public void DataReset()//This method is used to reset global data such as score and time
	{
        GlobalScore = 0f;
        GlobalTime = 0f;
        MazeQuestionNum = 0;
    }
}

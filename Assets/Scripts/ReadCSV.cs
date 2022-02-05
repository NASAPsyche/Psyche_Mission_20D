using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadCSV : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        ReadFromCSV();
    }

    void ReadFromCSV()
    {
        string folderPath = Application.dataPath;//relative path
        StreamReader reader = new StreamReader($"{folderPath}/WordBank.csv");
        bool EOF = false;
        while (!EOF)
		{
            string line = reader.ReadLine();
            if(line == null)//reach the end of file
			{
                EOF = true;
                break;
			}
            GameData.questionList.Add(line);//Add each line from csv file to questionList in global GameData
        }
    }
}

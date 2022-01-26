using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * This script creates a count-down timer.
 */
public class Timer : MonoBehaviour
{
    public float startTime = 60f;//default 60s, unless otherwise changed in Unity
    // Start is called before the first frame update

    public Text textDisplay;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startTime >= 10)// When time > 10, display integer only
		{
            textDisplay.text = startTime.ToString("0");
        }
		else if(startTime < 10 && startTime >0)// When time in between 0 - 10, display decimals
		{
            textDisplay.text = startTime.ToString();
        }
		else// When it hits 0, it fails
		{
            SceneManager.LoadScene("FailScene");
        }
        startTime -= Time.deltaTime;//reduce 1 second per second
    }
}

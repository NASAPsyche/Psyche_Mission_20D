using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This script is designed for maze player. The method Update is called once per frame.
 * The method Update is to handle left, right, up, down movement. The public variable "speed" can be accessed in Unity to change the speed of the player
 * Thw method OnCollisionEnter2D is used to handle the situation when the player object collides with other objects.
 * 
 */
public class maze_player : MonoBehaviour
{
    [SerializeField] float speed = 3.5f;
    [SerializeField] int maxQuestionNum = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
            transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
		}
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -1 * speed * Time.deltaTime, 0);
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.gameObject.tag == "Walls")
        {
            SceneManager.LoadScene("FailScene");
        }
        if (collision.gameObject.tag == "CorrectAnswer")
		{
            GameData.GlobalScore += 100;
            GameData.MazeQuestionNum++;
            Debug.Log(GameData.MazeQuestionNum);
            if(GameData.MazeQuestionNum >= maxQuestionNum) //Determine whether sufficient amount of questions have been asked
			{
               SceneManager.LoadScene("Level2");
			}
			else
			{
                SceneManager.LoadScene("Level1");
            }
		}
        if (collision.gameObject.tag == "IncorrectAnswer")
        {
            GameData.GlobalScore -= 50;
            SceneManager.LoadScene("Level1");
        }
    }
}

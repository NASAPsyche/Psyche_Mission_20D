using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script is used to load the next scene.
 * The public variable "nextLv" can be accessed in Unity to change which level will be the next
 */
public class Nextlvl : MonoBehaviour
{
	public string nextLv;
    public void nextLevel()
	{
		SceneManager.LoadScene(nextLv);
	}
}

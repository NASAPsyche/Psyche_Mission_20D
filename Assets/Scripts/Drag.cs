using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is inspired by Tarodev from https://www.youtube.com/watch?v=Tv82HIvKcZQ&list=PPSV
public class Drag : MonoBehaviour
{
	private Camera camObj;

	void Awake()
	{
		camObj = Camera.main;
	}

	void OnMouseDrag()
	{
		transform.position = GetMousePos();
	}
	Vector3 GetMousePos()
	{
		var mousePos = camObj.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0;
		return mousePos;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour
{
	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log("OnDrop");
	}
}
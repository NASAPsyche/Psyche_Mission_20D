using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{

    private GameObject selectedObject;
    private Vector3 offset;

    private GameObject answer1;
    private GameObject answer2;
    private GameObject answer3;
    private GameObject answer4;
    private Vector3 originalPosition;
    int wasAnswer = -1;

    void Start()
    {
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition, Physics.DefaultRaycastLayers, 0);
            if (targetObject)
            {
                if(targetObject.name == "To Menu Button")
                {
                    GameSettings.MainMenu();
                }
                selectedObject = targetObject.transform.gameObject;
                originalPosition = targetObject.transform.position;
                offset = selectedObject.transform.position - mousePosition;
                Collider2D answerObject = Physics2D.OverlapPoint(selectedObject.transform.position, Physics.DefaultRaycastLayers, -10, -1);
                if (answerObject)
                {
                    if (answerObject.name == "AnswerArea1")
                    {
                        answer1 = null;
                        wasAnswer = 1;
                    }
                    else if (answerObject.name == "AnswerArea2")
                    {
                        answer2 = null;
                        wasAnswer = 2;
                    }
                    else if (answerObject.name == "AnswerArea3")
                    {
                        answer3 = null;
                        wasAnswer = 3;
                    }
                    else
                    {
                        answer4 = null;
                        wasAnswer = 4;
                    }
                }
                SetButtonDisabled();
            }
        }
        if (selectedObject)
        {
            selectedObject.transform.position = mousePosition + offset;
        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            Collider2D answerObject = Physics2D.OverlapPoint(selectedObject.transform.position, Physics.DefaultRaycastLayers, -10, -1);
            if (answerObject)
            {
                if (answerObject.name == "AnswerArea1")
                {
                    if (answer1 == null)
                    {
                        answer1 = selectedObject;
                        selectedObject.transform.position = new Vector3(answerObject.transform.position.x, answerObject.transform.position.y, selectedObject.transform.position.z);
                    }
                    else
                    {
                        selectedObject.transform.position = originalPosition;
                        if(wasAnswer == 1)
                        {
                            answer1 = selectedObject;
                        }
                        else if (wasAnswer == 2)
                        {
                            answer2 = selectedObject;
                        }
                        else if (wasAnswer == 3)
                        {
                            answer3 = selectedObject;
                        }
                        else if (wasAnswer == 4)
                        {
                            answer4 = selectedObject;
                        }
                    }
                }
                else if (answerObject.name == "AnswerArea2")
                {
                    if (answer2 == null)
                    {
                        answer2 = selectedObject;
                        selectedObject.transform.position = new Vector3(answerObject.transform.position.x, answerObject.transform.position.y, selectedObject.transform.position.z);
                    }
                    else
                    {
                        selectedObject.transform.position = originalPosition;
                        if (wasAnswer == 1)
                        {
                            answer1 = selectedObject;
                        }
                        else if (wasAnswer == 2)
                        {
                            answer2 = selectedObject;
                        }
                        else if (wasAnswer == 3)
                        {
                            answer3 = selectedObject;
                        }
                        else if (wasAnswer == 4)
                        {
                            answer4 = selectedObject;
                        }
                    }
                }
                else if (answerObject.name == "AnswerArea3")
                {
                    if (answer3 == null)
                    {
                        answer3 = selectedObject;
                        selectedObject.transform.position = new Vector3(answerObject.transform.position.x, answerObject.transform.position.y, selectedObject.transform.position.z);
                    }
                    else
                    {
                        selectedObject.transform.position = originalPosition;
                        if (wasAnswer == 1)
                        {
                            answer1 = selectedObject;
                        }
                        else if (wasAnswer == 2)
                        {
                            answer2 = selectedObject;
                        }
                        else if (wasAnswer == 3)
                        {
                            answer3 = selectedObject;
                        }
                        else if (wasAnswer == 4)
                        {
                            answer4 = selectedObject;
                        }
                    }
                }
                else if (answer4 == null)
                {
                    answer4 = selectedObject;
                    selectedObject.transform.position = new Vector3(answerObject.transform.position.x, answerObject.transform.position.y, selectedObject.transform.position.z);
                }
                else
                {
                    selectedObject.transform.position = originalPosition;
                    if (wasAnswer == 1)
                    {
                        answer1 = selectedObject;
                    }
                    else if (wasAnswer == 2)
                    {
                        answer2 = selectedObject;
                    }
                    else if (wasAnswer == 3)
                    {
                        answer3 = selectedObject;
                    }
                    else if (wasAnswer == 4)
                    {
                        answer4 = selectedObject;
                    }
                }
                if (answer1 && answer2 && answer3 && answer4)
                {
                    SetButtonEnabled();
                }
            }
            else
            {
                SetButtonDisabled();
            }
            wasAnswer = -1;
            selectedObject = null;
        }
    }

    private static void SetButtonEnabled()
    {
        GameObject.Find("Advance").GetComponent<Button>().interactable = true;
    }

    private static void SetButtonDisabled()
    {
        GameObject.Find("Advance").GetComponent<Button>().interactable = false;
    }

}

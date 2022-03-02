using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{

    private GameObject selectedObject;
    private Vector3 offset;
    private static GameObject answer1;
    private static GameObject answer2;
    private static GameObject answer3;
    private static GameObject answer4;

    private static Question question1;
    private static Question question2;
    private static Question question3;
    private static Question question4;

    private Vector3 originalPosition;
    int wasAnswer = -1;
    private static bool won = false;

    Question getQuestion()
    {
        int value = Random.Range(0, GameSettings.questionList.questions.Length - 1);
        Question question = GameSettings.questionList.questions[value];
        var questionList = new List<Question>(GameSettings.questionList.questions);
        questionList.RemoveAt(value);
        GameSettings.questionList.questions = questionList.ToArray();
        return question;
    }

    void Start()
    {
        won = false;
        question1 = getQuestion();
        question2 = getQuestion();
        question3 = getQuestion();
        question4 = getQuestion();

        GameObject.Find("Question1").GetComponent<Text>().text = question1.question;
        GameObject.Find("Question2").GetComponent<Text>().text = question2.question;
        GameObject.Find("Question3").GetComponent<Text>().text = question3.question;
        GameObject.Find("Question4").GetComponent<Text>().text = question4.question;
        GameObject.Find("Answer1").GetComponent<Text>().text = question2.answers[1];
        GameObject.Find("Answer2").GetComponent<Text>().text = question4.answers[2];
        GameObject.Find("Answer3").GetComponent<Text>().text = question3.answers[0];
        GameObject.Find("Answer4").GetComponent<Text>().text = question3.answers[1];
        GameObject.Find("Answer5").GetComponent<Text>().text = question1.answers[0];
        GameObject.Find("Answer6").GetComponent<Text>().text = question2.answers[0];
        GameObject.Find("Answer7").GetComponent<Text>().text = question4.answers[1];
        GameObject.Find("Answer8").GetComponent<Text>().text = question4.answers[0];
        GameObject.Find("Answer9").GetComponent<Text>().text = question1.answers[1];
        GameObject.Find("Answer10").GetComponent<Text>().text = question3.answers[2];
        GameObject.Find("Answer11").GetComponent<Text>().text = question1.answers[2];
        GameObject.Find("Answer12").GetComponent<Text>().text = question2.answers[3];
        GameObject.Find("Answer13").GetComponent<Text>().text = question4.answers[3];
        GameObject.Find("Answer14").GetComponent<Text>().text = question2.answers[2];
        GameObject.Find("Answer15").GetComponent<Text>().text = question3.answers[3];
        GameObject.Find("Answer16").GetComponent<Text>().text = question1.answers[3];
    }

    void Update()
    {
        if (!won)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D targetObject = Physics2D.OverlapPoint(mousePosition, Physics.DefaultRaycastLayers, 0);
                if (targetObject)
                {
                    if (targetObject.name == "To Menu Button")
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
    }

    public static void Check()
    {
        if (won)
        {
            GameSettings.AdvanceGame();
        }
        else
        {
            string answer1Text = answer1.GetComponent<Text>().text;
            string answer2Text = answer2.GetComponent<Text>().text;
            string answer3Text = answer3.GetComponent<Text>().text;
            string answer4Text = answer4.GetComponent<Text>().text;

            won = true;
            if(answer1Text != question1.correct_answer)
            {
                GameObject.Find("Question1").GetComponent<Text>().color = Color.red;
                won = false;
            }
            else
            {
                GameObject.Find("Question1").GetComponent<Text>().color = Color.green;
            }
            if (answer2Text != question2.correct_answer)
            {
                GameObject.Find("Question2").GetComponent<Text>().color = Color.red;
                won = false;
            }
            else
            {
                GameObject.Find("Question2").GetComponent<Text>().color = Color.green;
            }
            if (answer3Text != question3.correct_answer)
            {
                GameObject.Find("Question3").GetComponent<Text>().color = Color.red;
                won = false;
            }
            else
            {
                GameObject.Find("Question3").GetComponent<Text>().color = Color.green;
            }
            if (answer4Text != question4.correct_answer)
            {
                GameObject.Find("Question4").GetComponent<Text>().color = Color.red;
                won = false;
            }
            else
            {
                GameObject.Find("Question4").GetComponent<Text>().color = Color.green;
            }
            if (won)
            {
                GameObject.Find("Text").GetComponent<Text>().text = "Advance";
            }
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

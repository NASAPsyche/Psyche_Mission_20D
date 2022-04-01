using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{

    //Variables related to the drag and drop system
    private GameObject selectedObject;
    private Vector3 offset;
    private Vector3 previousPosition;
    private int wasAnswer = -1;
    private List<Vector3> originalPositions;

    //Stored answers for each of the 4 questions
    private static GameObject answer1;
    private static GameObject answer2;
    private static GameObject answer3;
    private static GameObject answer4;

    //The four selected questions and the list of possible answers
    private static Question question1;
    private static Question question2;
    private static Question question3;
    private static Question question4;
    private List<string> answers;

    //Whether the game has been won (to lock drag and drop)
    private static bool won = false;

    //Global variable
    public static bool isCorrect = true;

    //Initalize the game on page load
    void Start()
    {
        won = false;
        SetOriginalPositions();
        GetQuestions();
        InitializeAnswerArray();
        AssignAnswers();
        GameObject.Find("check1").GetComponent<Image>().enabled = false;
        GameObject.Find("check2").GetComponent<Image>().enabled = false;
        GameObject.Find("check3").GetComponent<Image>().enabled = false;
        GameObject.Find("check4").GetComponent<Image>().enabled = false;
        GameObject.Find("cross1").GetComponent<Image>().enabled = false;
        GameObject.Find("cross2").GetComponent<Image>().enabled = false;
        GameObject.Find("cross3").GetComponent<Image>().enabled = false;
        GameObject.Find("cross4").GetComponent<Image>().enabled = false;
    }

    //Stores the original positions of the answers if one is drug out of an answer slot
    private void SetOriginalPositions()
    {
        originalPositions = new List<Vector3>
        {
            GameObject.Find("Answer1").transform.position, GameObject.Find("Answer2").transform.position,
            GameObject.Find("Answer3").transform.position, GameObject.Find("Answer4").transform.position,
            GameObject.Find("Answer5").transform.position, GameObject.Find("Answer6").transform.position,
            GameObject.Find("Answer7").transform.position, GameObject.Find("Answer8").transform.position
        };
    }

    //Randomly selects four questions to ask
    private void GetQuestions()
    {
        question1 = GameSettings.GetRandomQuestion();
        question2 = GameSettings.GetRandomQuestion();
        question3 = GameSettings.GetRandomQuestion();
        question4 = GameSettings.GetRandomQuestion();
        GameObject.Find("Question1").GetComponent<Text>().text = question1.question;
        GameObject.Find("Question2").GetComponent<Text>().text = question2.question;
        GameObject.Find("Question3").GetComponent<Text>().text = question3.question;
        GameObject.Find("Question4").GetComponent<Text>().text = question4.question;
    }

    //Creates a list of all correct and incorrect answers
    private void InitializeAnswerArray()
    {
        answers = new List<string>
        {
            question1.correct_answer, question1.wrong_answer, question2.correct_answer, question2.wrong_answer, question3.correct_answer, question3.wrong_answer, question4.correct_answer, question4.wrong_answer
        };
    }

    //Assigns an answer to each answer slot, making sure any empty answers are at the bottom of the list
    private void AssignAnswers()
    {
        for(int i=1; i<=8; i++)
        {
            string answer = "";
            while(answer == "" && answers.Count > 0)
            {
                answer = AssignRandomAnswer();
            }

            GameObject answerObject = GameObject.Find("Answer" + i);
            answerObject.GetComponent<Text>().text = answer;
            if(answer == "")
            {
                answerObject.transform.position = new Vector3(answerObject.transform.position.x, answerObject.transform.position.y, 10);
            }
        }
    }

    //Get a random answer value from the list
    private string AssignRandomAnswer()
    {
        int value = Random.Range(0, answers.Count - 1);
        string answer = answers[value];
        answers.RemoveAt(value);
        return answer;
    }

    //Runs when the mouse is pressed down. Selects an answer object if one is available (or goes to the menu if it is clicked)
    private void SelectObject(Vector3 mousePosition)
    {
        Collider2D targetObject = Physics2D.OverlapPoint(mousePosition, Physics.DefaultRaycastLayers, 0);
        if (targetObject)
        {
            if (targetObject.name == "To Menu Button")
            {
                GameSettings.MainMenu();
            }
            selectedObject = targetObject.transform.gameObject;
            previousPosition = targetObject.transform.position;
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
            if(!answer1 && !answer2 && !answer3 && !answer4)
            {
                SetButtonDisabled();
            }
        }
    }

    //Return back to the last spot if drug to an incorrect position
    private void ReturnToPreviousPosition()
    {
        selectedObject.transform.position = previousPosition;
        switch (wasAnswer)
        {
            case 1:
                answer1 = selectedObject;
                break;
            case 2:
                answer2 = selectedObject;
                break;
            case 3:
                answer3 = selectedObject;
                break;
            case 4:
                answer4 = selectedObject;
                break;
        }
    }

    //Snap back to the original position if dropped from an answer slot
    private void ReturnToOriginalPosition()
    {
        int answerNum = System.Int32.Parse(""+selectedObject.name[selectedObject.name.Length - 1]);
        selectedObject.transform.position = originalPositions[answerNum - 1];
    }

    //Drop an object when the mouse is released
    private void DropObject(Vector3 mousePosition)
    {
        Collider2D answerObject = Physics2D.OverlapPoint(selectedObject.transform.position, Physics.DefaultRaycastLayers, -10, -1);
        if (answerObject)
        {
            selectedObject.transform.position = new Vector3(answerObject.transform.position.x, answerObject.transform.position.y, selectedObject.transform.position.z);
            switch (answerObject.name)
            {
                case "AnswerArea1":
                    if (answer1)
                    {
                        ReturnToPreviousPosition();
                    }
                    else
                    {
                        answer1 = selectedObject;
                    }
                    break;
                case "AnswerArea2":
                    if (answer2)
                    {
                        ReturnToPreviousPosition();
                    }
                    else
                    {
                        answer2 = selectedObject;
                    }
                    break;
                case "AnswerArea3":
                    if (answer3)
                    {
                        ReturnToPreviousPosition();
                    }
                    else
                    {
                        answer3 = selectedObject;
                    }
                    break;
                case "AnswerArea4":
                    if (answer4)
                    {
                        ReturnToPreviousPosition();
                    }
                    else
                    {
                        answer4 = selectedObject;
                    }
                    break;
            }
        }
        else
        {
            if (wasAnswer != -1)
            {
                //In this particular situation, return the answer to a position it was not just in (Answer drug from answer slot to empty space)
                ReturnToOriginalPosition();
            }
            else
            {
                ReturnToPreviousPosition();
            }
        }

        if (answer1 || answer2 || answer3 || answer4)
        {
            SetButtonEnabled();
        }

        wasAnswer = -1;
        selectedObject = null;
    }

    void Update()
    {
        //Stop allowed drag and drop when the game has been won
        if (!won)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                SelectObject(mousePosition);
            }
            if (selectedObject)
            {
                selectedObject.transform.position = mousePosition + offset;
            }
            if (Input.GetMouseButtonUp(0) && selectedObject)
            {
                DropObject(mousePosition);
            }
        }
    }

    //Check the answers for the game to see if the player can move on
    public static void Check()
    {
        if (won)
        {
            GameSettings.AdvanceGame();
        }
        else
        { 
            int counter = 0;

            if (answer1)
            {
                string answerText = answer1.GetComponent<Text>().text; 
                if (answerText == question1.correct_answer)
                {
                    //GameObject.Find("Question1").GetComponent<Text>().color = Color.green;
                    //answerText = GameObject.Find("Question1").GetComponent<Text>().text.Insert(0, "✔️");
                    //GameObject.Find("Question1").GetComponent<Text>().text = answerText;
                    GameObject.Find("check1").GetComponent<Image>().enabled = true;
                    GameObject.Find("cross1").GetComponent<Image>().enabled = false;
                    counter++;
                }
                else
                {
                    //GameObject.Find("Question1").GetComponent<Text>().color = Color.red;
                    //string wrongAnswer = GameObject.Find("Question1").GetComponent<Text>().text.Insert(0, '\u2573'.ToString() + " ");
                    //GameObject.Find("Question1").GetComponent<Text>().text = wrongAnswer; 
                    GameObject.Find("check1").GetComponent<Image>().enabled = false;
                    GameObject.Find("cross1").GetComponent<Image>().enabled = true;
                }
            }
            else
            {
                //GameObject.Find("Question1").GetComponent<Text>().color = Color.white;
                GameObject.Find("check1").GetComponent<Image>().enabled = false;
                GameObject.Find("cross1").GetComponent<Image>().enabled = false;
            }

            if(answer2)
            {
                string answerText = answer2.GetComponent<Text>().text;
                if (answerText == question2.correct_answer)
                {
                    GameObject.Find("check2").GetComponent<Image>().enabled = true;
                    GameObject.Find("cross2").GetComponent<Image>().enabled = false;
                    counter++;
                }
                else
                {
                    GameObject.Find("check2").GetComponent<Image>().enabled = false;
                    GameObject.Find("cross2").GetComponent<Image>().enabled = true;
                }
            }
            else
            {
                GameObject.Find("check2").GetComponent<Image>().enabled = false;
                GameObject.Find("cross2").GetComponent<Image>().enabled = false;
            }

            if (answer3)
            {
                string answerText = answer3.GetComponent<Text>().text;
                if (answerText == question3.correct_answer)
                {
                    GameObject.Find("check3").GetComponent<Image>().enabled = true;
                    GameObject.Find("cross3").GetComponent<Image>().enabled = false;
                    counter++;
                }
                else
                {
                    GameObject.Find("check3").GetComponent<Image>().enabled = false;
                    GameObject.Find("cross3").GetComponent<Image>().enabled = true;
                }
            }
            else
            {
                GameObject.Find("check3").GetComponent<Image>().enabled = false;
                GameObject.Find("cross3").GetComponent<Image>().enabled = false;
            }

            if (answer4)
            {
                string answerText = answer4.GetComponent<Text>().text;
                if (answerText == question4.correct_answer)
                {
                    GameObject.Find("check4").GetComponent<Image>().enabled = true;
                    GameObject.Find("cross4").GetComponent<Image>().enabled = false;
                    counter++;
                }
                else
                {
                    GameObject.Find("check4").GetComponent<Image>().enabled = false;
                    GameObject.Find("cross4").GetComponent<Image>().enabled = true;
                }
            }
            else
            {
                GameObject.Find("check4").GetComponent<Image>().enabled = false;
                GameObject.Find("cross4").GetComponent<Image>().enabled = false;
            }

            if (counter == 4)
            {
                won = true;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

struct QuestionData 
{
    public int id;
    public string correctAnswer;
    public string[] inCorrectAnswer;

}
public class Question : MonoBehaviour
{
    public GameObject answerTextParentObj;
    public GameObject questionTextParentObj;
    public GameObject[] answerPanelObj;
    List<QuestionData> questionDatas = new List<QuestionData>();
    List<string> answerText = new List<string>();
	// Start is called before the first frame update
	// Question does not need to update evert frame, only the beginning
	void Start()
	{
		ShowQuestionData();
		ShowAnswerInCorrectText();
	}
    bool isLock = false;
    Transform currentButtonTrans;
    Vector3 currentButtonOrigin = Vector3.zero;
    Vector3 mouseUpPosition = Vector3.zero;
    string currentTempStr = "";
    bool isReadyDelay = false;
    int dealyFrame = 0;
	void Update()
	{
        if (Input.GetMouseButtonDown(0))
		{
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(new Vector2(ray.origin.x, ray.origin.y), Vector2.zero, Mathf.Infinity);
            if (hit.collider != null)
			{
                if (hit.collider.tag == "Answer")
                {
                    currentButtonOrigin = hit.transform.position;
                    isLock = true;
                    currentButtonTrans = hit.transform;
                    hit.transform.position = GetMousePos();
                }
			}
        }
        if (isReadyDelay)
		{
            dealyFrame++;
		}
            //Check in the next frame
            if (mouseUpPosition != Vector3.zero&&dealyFrame>10)
        {
            //Check whether hit the answer panel tag
            var ray = Camera.main.ScreenPointToRay(mouseUpPosition);
            var hit = Physics2D.Raycast(new Vector2(ray.origin.x, ray.origin.y), Vector2.zero, Mathf.Infinity);
            if (hit.collider != null)
            {
                print(hit.collider.tag);
                if (hit.collider.tag == "AnswerPanel")
                {
                    //After hitting, check the reference of the question to the answer
                    int index = hit.transform.GetComponent<AnswerTextConfirm>().currentIndex;
                    QuestionData questionData = questionDatas[index];
                    if (questionData.correctAnswer == currentTempStr)
                    {
                        GameData.GlobalScore += 100;
                        print("answer right");
                    }
                    else
                    {
                        GameData.GlobalScore -= 30;
                        print("answer fail");
                    }
                }
            }
            mouseUpPosition = Vector3.zero;
            currentTempStr = "";
            dealyFrame = 0;
            isReadyDelay = false;
        }
        if (isLock && currentButtonTrans != null)
		{
            currentButtonTrans.position = GetMousePos();
        }
        if (Input.GetMouseButtonUp(0))
		{
            currentTempStr = currentButtonTrans.GetChild(0).GetComponent<Text>().text;
            isLock = false;
            currentButtonTrans.position = currentButtonOrigin;
            currentButtonTrans = null;
            currentButtonOrigin = Vector3.zero;
            mouseUpPosition = Input.mousePosition;
            isReadyDelay = true;
        }
    }
	void LateUpdate()
	{
    }
	Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
    void ShowQuestionData()
	{
		for (int i = 0; i < 4; i++)
		{
            string[] lines = GetQuestionData();
            questionTextParentObj.transform.GetChild(i).GetComponent<Text>().text = lines[0];
            answerText.Add(lines[1]);
            answerText.Add(lines[2]);
            answerText.Add(lines[3]);
            answerText.Add(lines[4]);
            questionDatas.Add(new QuestionData() { id = i, correctAnswer = lines[1], inCorrectAnswer = new string[] { lines[2], lines[3], lines[4] } });
        }
	}
    string[] GetQuestionData()
    {
        int rnd = Random.Range(0, GameData.questionList.Count);
        string[] line = GameData.questionList[rnd].ToString().Split(',');
        GameData.questionList.RemoveAt(rnd);
        return line;
    }
    void ShowAnswerInCorrectText()
	{
		for (int i = 0; i < answerTextParentObj.transform.childCount; i++)
		{
            if (answerText.Count > 0)
			{
                int rand = Random.Range(0, answerText.Count);
                answerTextParentObj.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = answerText[rand];
                GameObject obj = answerTextParentObj.transform.GetChild(i).gameObject;
                answerText.RemoveAt(rand);
            }
		}
	}
    void AnswerButonClick(GameObject currentButton)
	{
        currentButtonOrigin = currentButton.transform.position;
        isLock = true;
        currentButtonTrans = currentButton.transform;
	}
}

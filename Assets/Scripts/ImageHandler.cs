using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject img;
    
    void Start()
    {
        img.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       if (GameScript.isCorrect)
            img.SetActive(true);
       else
            img.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearCanvasController : MonoBehaviour
{
    public Canvas canvas;

    public Text inputText;
    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonOK()
    {
        if (inputText.text == "30052000")
        {
            canvas.enabled = false;
            HighScoreArrayList.DeleteScoresFromList();
            HighScoreMenuScript.ClearTable();
        }
        else
        {
            canvas.enabled = false;
        }
    }
}

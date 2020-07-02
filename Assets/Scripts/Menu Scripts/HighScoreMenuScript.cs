using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreMenuScript : MonoBehaviour
{
    public Canvas HighScoreCanvas;

    public Canvas PasswordCanvas;

    public static void CreateTable()
    {
        try
        {
            for (int i = 0; i < HighScoreArrayList.list.Capacity; i++)
            {
                GameObject.Find("Score" + (i + 1).ToString()).GetComponent<ScoreController>().MakeText(HighScoreArrayList.list[i].timeInSeconds, HighScoreArrayList.list[i].Name, HighScoreArrayList.list[i].kills);
            }
            HighScoreArrayList.list.Clear();
        }
        catch
        {

        }
    }

    public static void ClearTable()
    {
        try
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject.Find("Score" + (i + 1).ToString()).GetComponent<ScoreController>().MakeClear();
            }
        }
        catch
        {

        }
    }
    private void Start()
    {
        
    }
    public void BackToMainMenu()
    {
        HighScoreArrayList.list.Clear();
        HighScoreCanvas.enabled = !HighScoreCanvas.enabled;
    }

    public void ClearButton()
    {
        PasswordCanvas.enabled = !PasswordCanvas.enabled;
    }
}

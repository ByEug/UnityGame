using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CanvasDoneController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Time;
    public Text Kills;
    public Text InputText;

    public Canvas canvas;
    public void EnterFields(float time, int kills)
    {
        double buffer = Math.Round(time, 2);
        time = (float)buffer;
        Time.text = "Time: " + time.ToString();
        Kills.text = "Kills: " + kills.ToString();
    }

    public void pushOK()
    {
        if (InputText.text != "")
        {
            HighScoreClass buffer = new HighScoreClass(PlayerController.time, InputText.text, PlayerController.kills);
            HighScoreArrayList.LoadScoresToList();
            HighScoreArrayList.list.Add(buffer);
            HighScoreArrayList.list.Sort(new HighScoreClassComparer());
            if (HighScoreArrayList.list.Capacity > 10)
            {
                HighScoreArrayList.list.RemoveAt(10);
            }
            HighScoreArrayList.UploadFileFromList();
            //SceneManager.UnloadSceneAsync("SceneForest_lvl_1");

            SceneManager.LoadScene("MainMenu");
        }
    }
    void Start()
    {
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

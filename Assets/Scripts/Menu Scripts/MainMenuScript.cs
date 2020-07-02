using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Canvas Highscore;

    public Canvas settings;
    private void Start()
    {
        Highscore.enabled = false;
        settings.enabled = false;
        Time.timeScale = 1f;
        //Debug.Log(Application.persistentDataPath);
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("InventoryCanvas"));
        Destroy(GameObject.Find("MainCameraPlayer"));
        Destroy(GameObject.Find("CanvasHealth"));
        Destroy(GameObject.Find("In-gameConsole"));
        Destroy(GameObject.Find("PauseCanvas"));
        Destroy(GameObject.Find("EventSystem"));
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadGame()
    {
        PlayerDataToSave buffer = SerializingSystem.LoadPlayer();
        if (buffer != null)
        {
            PlayerController.serialization = true;
            PlayerController.data = buffer;
            if (buffer.SceneName == "SampleScene")
            {
                SceneManager.LoadSceneAsync(buffer.SceneName);
            }
            else
            {
                SceneManager.LoadSceneAsync("SampleScene");
                SceneManager.LoadSceneAsync(buffer.SceneName);
            }
        }
        
    }

    public void HighScores()
    {
        try
        {
            Highscore.GetComponent<Canvas>();
            HighScoreArrayList.LoadScoresToList();
            Highscore.enabled = !Highscore.enabled;
            HighScoreMenuScript.CreateTable();
        }
        catch
        {

        }
    }

    public void Settings()
    {
        settings.GetComponent<Canvas>();
        settings.enabled = !settings.enabled;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

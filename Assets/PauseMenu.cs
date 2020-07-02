using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject player;

    public GameObject PauseMenuUI;

    public void SaveGameButton()
    {
        SerializingSystem.SavePlayer(player);
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1f;
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void GoToMainMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        //SceneManager.UnloadSceneAsync("SampleScene");
        GameObject.Find("MainCameraPlayer").GetComponent<AudioListener>().enabled = false;
        SceneManager.LoadScene("MainMenu");

    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    void Start()
    {
        PauseMenuUI.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}

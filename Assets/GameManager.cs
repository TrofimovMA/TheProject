using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject fpsText;


    void Start()
    {
        fpsText.SetActive(GameData.showFps);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (PausePanel.activeInHierarchy)
                GoToGame();
            else
                GoToPauseMenu();
    }

    public void GoToPauseMenu()
    {
        PausePanel.SetActive(true);
        fpsText.SetActive(false);
        Time.timeScale = 0;
    }

    public void GoToGame()
    {
        PausePanel.SetActive(false);
        fpsText.SetActive(GameData.showFps);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject FPStext;


    void Start()
    {
        
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
    }

    public void GoToGame()
    {
        PausePanel.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
}

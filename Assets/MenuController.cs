using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionMenu;

    void Start()
    {
        GoToMainMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (OptionMenu.activeInHierarchy)
                GoToMainMenu();
            else
                Exit();
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToMainMenu()
    {
        MainMenu.SetActive(true);
        OptionMenu.SetActive(false);
    }

    public void GoToOptionMenu()
    {
        MainMenu.SetActive(false);
        OptionMenu.SetActive(true);
    }

    public void ToggleShowFPS(Toggle change)
    {
        GameData.showFps = change.isOn;
        Debug.Log("STATUS " + change.isOn);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

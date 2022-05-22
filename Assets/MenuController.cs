using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionMenu;

    // Start is called before the first frame update
    void Start()
    {
        GoToMainMenu();
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

    public void Exit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}

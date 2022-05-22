using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionMenu;
    public Dropdown RDropdown;
    public Dropdown QDropdown;
    Resolution[] resolutions;
    string[] qualities;

    void Start()
    {
        Time.timeScale = 1;

        GoToMainMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (OptionMenu.activeInHierarchy)
                GoToMainMenu();
            else
                Exit();

        if(Input.GetKeyDown(KeyCode.Q))
        {
            Screen.SetResolution(640, 480, false);
            Debug.Log("RES CHANGGE " + Screen.currentResolution.width + "/" + Screen.currentResolution.height);
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        Debug.Log("RES CHANGGE " + resolution.width + "/" + resolution.height);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log("QUALITY CHANGGE " + qualityIndex);
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

        resolutions = Screen.resolutions;
        RDropdown.ClearOptions();
        List<string> options = new List<string>();
        int curResolutonIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            if (Screen.currentResolution.width == resolutions[i].width &&
                Screen.currentResolution.height == resolutions[i].height)
                curResolutonIndex = i;
            options.Add(option);
        }
        RDropdown.AddOptions(options);
        RDropdown.value = curResolutonIndex;
        RDropdown.RefreshShownValue();

        qualities = QualitySettings.names;
        QDropdown.ClearOptions();
        List<string>qoptions = new List<string>();
        int curQualityIndex = QualitySettings.GetQualityLevel();
        for (int i = 0; i < qualities.Length; i++)
        {
            string option = qualities[i];
            qoptions.Add(option);
        }
        QDropdown.AddOptions(qoptions);
        QDropdown.value = curQualityIndex;
        QDropdown.RefreshShownValue();
    }

    public void ToggleShowFPS(Toggle change)
    {
        GameData.showFps = change.isOn;
        Debug.Log("STATUS " + change.isOn);
    }

    public void ToggleFS(bool change)
    {
        GameData.fullScreen = change;
        Screen.fullScreen = change;
        Debug.Log("STATUS " + change);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Reflection;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    private int score=0;
    public int Score { get { return score; } set { score = value; UpdateUIScore(); } }
    public GameObject PausePanel;
    public GameObject fpsText;
    public Text scoreText;
    public GameObject SpawnPoint1;
    public GameObject SpawnPoint2;
    public List<(GameObject obj, bool counted)> NPClist;

    void UpdateUIScore()
    {
        Debug.Log("Score: " + Score);
        scoreText.text = "Score: " + Score;
    }

    void a()
    {
        addNPCtoList(fpsText);
    }

    void b()
    {
        deleteNPCtoList(fpsText);
    }

    void c()
    {
        //ClearLog();
        Debug.Log("---");
        int c = 0;
        foreach((GameObject obj, bool counted) x in NPClist)
        {
            Debug.Log((c++) + ": " + x.obj.name + " / " + x.counted);
        }
    }

    void d()
    {
        setNPCinList(fpsText, !NPClist[NPClist.FindIndex(x => x.obj == fpsText)].counted);
    }

    void e()
    {
        //ClearLog();
        Debug.Log("---");
        int c = 0;
        foreach ((GameObject obj, bool counted) x in NPClist)
        {
            Debug.Log((c++) + ": " + x.obj.name + " / " + x.obj.transform.position);
            if (c > 3) break;
        }
    }

    public void addNPCtoList(GameObject obj)
    {
        List<GameObject> tList = NPClist.Select(x => x.obj).ToList();

        if (tList.Contains(obj))
            return;

        NPClist.Add((obj, false));
    }

    public void deleteNPCtoList(GameObject obj)
    {
        List<GameObject> tList = NPClist.Select(x => x.obj).ToList();

        if (!tList.Contains(obj))
            return;

        NPClist.RemoveAll(x => x.obj == obj);
    }

    public void setNPCinList(GameObject obj, bool counted)
    {
        int pairIndex = NPClist.FindIndex(x => x.obj == obj);
        if (pairIndex == -1)
        {
            Debug.Log("NOT FOUND");
            return;
        }
        NPClist[pairIndex] = (obj, counted);      
    }


    void Start()
    {
        fpsText.SetActive(GameData.showFps);
        Time.timeScale = 1;
        NPClist = new List<(GameObject obj, bool counted)>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            a();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            b();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            c();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            d();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            e();
        }
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

    //public void ClearLog()
    //{
    //    var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
    //    var type = assembly.GetType("UnityEditor.LogEntries");
    //    var method = type.GetMethod("Clear");
    //    method.Invoke(new object(), null);
    //}
}

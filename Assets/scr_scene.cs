using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_scene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string tmp = "*";
        GetComponent<Text>().text = "High Score:\n";
        for (int i = 0; i < 10; i++)
        {
            if(PlayerPrefs.HasKey(tmp) == false)
            {
                PlayerPrefs.SetInt(tmp, 0);
            }
            GetComponent<Text>().text += i+1;
            GetComponent<Text>().text += ": ";
            GetComponent<Text>().text += PlayerPrefs.GetInt(tmp);
            GetComponent<Text>().text += "\n";
            tmp += "*";
        }
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void changescene()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void quitgame()
    {
        Application.Quit();
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }
}

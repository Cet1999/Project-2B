using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_pause : MonoBehaviour
{
    [SerializeField]
    public GameObject pausePanel;
    public AudioSource music;
    public AudioSource sfx;
    void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeInHierarchy)
            {
                PauseGame();
            }
            else if (pausePanel.activeInHierarchy)
            {
                ContinueGame();
            }
        }
    }
    private void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetFloat ("music", music.volume);
        int i;
        if (music.enabled)
        {
            i = 1;
        } else
        {
            i = 0;
        }
        PlayerPrefs.SetInt("music_enable", i);

        PlayerPrefs.SetFloat("sfx", sfx.volume);
        int j;
        if (sfx.enabled)
        {
            j = 1;
        }
        else
        {
            j = 0;
        }
        PlayerPrefs.SetInt("sfx_enable", j);
        PlayerPrefs.Save();
        pausePanel.SetActive(false);
        //enable the scripts again
    }
}
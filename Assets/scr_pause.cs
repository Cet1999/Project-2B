using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_pause : MonoBehaviour
{
    [SerializeField]
    public GameObject pausePanel;
    void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
        Debug.Log("space!~");
        pausePanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;
        Debug.Log("start!~");
        pausePanel.SetActive(false);
        //enable the scripts again
    }
}
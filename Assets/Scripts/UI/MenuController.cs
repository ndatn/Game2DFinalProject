using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : Singleton<MenuController>
{
    public GameObject menuPanel;
    public GameObject mapPanel;
    private bool isPaused = false;

    private bool isMenuVisible = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
            if (isMenuVisible)
            {
                menuPanel.SetActive(false);
                isMenuVisible = false;
            }
            else
            {
                menuPanel.SetActive(true);
                isMenuVisible = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isMenuVisible)
            {
                mapPanel.SetActive(false);
                isMenuVisible = false;
            }
            else
            {
                mapPanel.SetActive(true);
                isMenuVisible = true;
            }
        }

    }

    public void PauseGame()
    {
        Time.timeScale = 0f; 
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; 
        isPaused = false;
       
    }

}
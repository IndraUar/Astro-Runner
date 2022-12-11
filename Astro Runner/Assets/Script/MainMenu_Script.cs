using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script for functions in Main Menu and Mode Select and main menu in pause

public class MainMenu_Script : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject ModePanel;
    public GameObject ShopPanel;
    public GameObject ScoreboardPanel;

    void Start()
    {
        MainPanel.SetActive(true);
        ModePanel.SetActive(false);
        ShopPanel.SetActive(false);
        ScoreboardPanel.SetActive(false);
    }

    public void QuitGame()
    {
        print("Quit Game~!");
        Application.Quit();
    }

    public void Play()
    {
        ModePanel.SetActive(true);
        MainPanel.SetActive(false);
        ShopPanel.SetActive(false);
        ScoreboardPanel.SetActive(false);
    }

    public void Shop()
    {
        ShopPanel.SetActive(true);
        ModePanel.SetActive(false);
        MainPanel.SetActive(false);
        ScoreboardPanel.SetActive(false);
    }
    public void ScoreBoard()
    {
        ScoreboardPanel.SetActive(true);
        ShopPanel.SetActive(false);
        ModePanel.SetActive(false);
        MainPanel.SetActive(false);
    }

    public void BackShop()
    {
        MainPanel.SetActive(true);
        ModePanel.SetActive(false);
        ShopPanel.SetActive(false);
        ScoreboardPanel.SetActive(false);
    }

    public void BackMode()
    {
        MainPanel.SetActive(true);
        ModePanel.SetActive(false);
        ShopPanel.SetActive(false);
        ScoreboardPanel.SetActive(false);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadNoob()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level_Noob");
    }

    public void LoadNormal()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level_Normal");
    }

    public void LoadPro()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Level_Pro");
    }
}

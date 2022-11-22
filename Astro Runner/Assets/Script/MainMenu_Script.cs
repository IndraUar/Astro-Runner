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

    void Start()
    {
        MainPanel.SetActive(true);
        ModePanel.SetActive(false);
        ShopPanel.SetActive(false);
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
    }

    public void Shop()
    {
        ShopPanel.SetActive(true);
        ModePanel.SetActive(false);
        MainPanel.SetActive(false);
    }

    public void BackShop()
    {
        MainPanel.SetActive(true);
        ModePanel.SetActive(false);
        ShopPanel.SetActive(false);
    }

    public void BackMode()
    {
        MainPanel.SetActive(true);
        ModePanel.SetActive(false);
        ShopPanel.SetActive(false);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    // this are all game modes.. just making 1 for now
    public void LoadNoob()
    {
        SceneManager.LoadScene("Level_Noob");
    }

    public void LoadNormal()
    {
        SceneManager.LoadScene("Level_Normal");
    }

    public void LoadPro()
    {
        SceneManager.LoadScene("Level_Pro");
    }
}

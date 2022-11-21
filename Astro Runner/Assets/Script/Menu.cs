using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject PauseButton;
    [SerializeField] GameObject LeaderBoard;


    [SerializeField] int[] Score;

    [SerializeField] TextMeshProUGUI[] Text_Score;

    private bool isActive_LeaderBoard;
    public int[] ScoreArray;
    private int temp;
    private void Start()
    {
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        LeaderBoard.SetActive(false);

        for(int i = 0; i < 5; i++)
        {
            PlayerPrefs.GetInt("Score" + i, Score[i]);
            ScoreArray[i] = Score[i];
        }

        for(int i = 0; i < ScoreArray.Length; i++)
        {
            for(int j = 0; j< ScoreArray.Length;j++)
            {
                if(ScoreArray[j] > ScoreArray[j+1])
                {
                    ScoreArray[j] = temp;
                    ScoreArray[j] = ScoreArray[j+1];
                    ScoreArray[j + 1] = temp;
                }
            }
        }
    }
    public void Pause()
    {
        Time.timeScale = 0.0f;
        PauseMenu.SetActive(true);
        PauseButton.SetActive(false);
    }

    public void CloseButton()
    {
        Time.timeScale = 1.0f;
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
    }

    public void ScoreBoard()
    {
        LeaderBoard.SetActive(!isActive_LeaderBoard);
        isActive_LeaderBoard = !isActive_LeaderBoard;
        for (int j = 0; j<5;j++)
        {
            Text_Score[j].text = Score[j].ToString("0");
        }
    }
}

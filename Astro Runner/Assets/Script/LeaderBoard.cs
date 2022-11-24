using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Score1;
    [SerializeField] TextMeshProUGUI Score2;
    [SerializeField] TextMeshProUGUI Score3;
    [SerializeField] TextMeshProUGUI Score4;
    [SerializeField] TextMeshProUGUI Score5;

    public Score score_script;

    private int Score_1;
    private int Score_2;
    private int Score_3;
    private int Score_4;
    private int Score_5;

    private int current_score = 0;

    private int[] Array_Score;

    // Start is called before the first frame update
    void Start()
    {
        Score_1 = PlayerPrefs.GetInt("score1", 0);
        Score_2 = PlayerPrefs.GetInt("score2", 0);
        Score_3 = PlayerPrefs.GetInt("score3", 0);
        Score_4 = PlayerPrefs.GetInt("score4", 0);
        Score_5 = PlayerPrefs.GetInt("score5", 0);

        Array_Score = new int[6];
        Array_Score[0] = Score_1;
        Array_Score[1] = Score_2;
        Array_Score[2] = Score_3;
        Array_Score[3] = Score_4;
        Array_Score[4] = Score_5;

        Score1.text = Score_1.ToString("0");
        Score2.text = Score_2.ToString("0");
        Score3.text = Score_3.ToString("0");
        Score4.text = Score_4.ToString("0");
        Score5.text = Score_5.ToString("0");
    }

    public void SortScore()
    {
        for(int i =0; i<Array_Score.Length-1;i++)
        {
            for(int j = 0; j < Array_Score.Length - i-1; j++)
            {
                if (Array_Score[j] < Array_Score[j+1])
                {
                    int temp = Array_Score[j];
                    Array_Score[j] = Array_Score[j+1];
                    Array_Score[j+1] = temp;
                }
            }
        }
    }

    public void RecoredScore()
    {
        current_score = (int)score_script.RecordScore;
        Array_Score[5] = current_score;
        SortScore();
        SaveScore();

    }

    public void SaveScore()
    {
        for(int i = 0;i<5;i++)
        {
            PlayerPrefs.SetInt("score" + (i + 1), Array_Score[i]);
            Debug.Log("score" + (i + 1));
        }
        Debug.Log(Array_Score[0]);
        Debug.Log(Array_Score[5]);
        //PlayerPrefs.SetInt("score1", Score_1);
        //PlayerPrefs.SetInt("score2", Score_2);
        //PlayerPrefs.SetInt("score3", Score_3);
        //PlayerPrefs.SetInt("score4", Score_4);
        //PlayerPrefs.SetInt("score5", Score_5);
    }
}

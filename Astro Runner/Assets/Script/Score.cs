using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// To manage the score system which goes up overtime and shows at the lose panel

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Text_Score;
    [SerializeField] TextMeshProUGUI Text_FinalScore;

    public float CurrentScore;

    void Start()
    {
        CurrentScore = 0;
    }

    void Update()
    {

        CurrentScore += Time.deltaTime;
        Text_Score.text = CurrentScore.ToString("0");
        Text_FinalScore.text = CurrentScore.ToString("0");
    }
}


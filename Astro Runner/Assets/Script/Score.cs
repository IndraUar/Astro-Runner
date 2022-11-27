using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// To manage the score system which goes up overtime and shows at the lose panel

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Text_Score;
    [SerializeField] TextMeshProUGUI Text_FinalScore;

    public float RecordScore;

    void Start()
    {
        RecordScore = 0;
    }

    void FixedUpdate()
    {
        RecordScore += Time.deltaTime;
        Text_Score.text = RecordScore.ToString("0");
    }

    void Update()
    {
        Text_FinalScore.text = RecordScore.ToString("0");
    }
}

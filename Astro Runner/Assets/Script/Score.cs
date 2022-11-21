using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Text_Score;

    public float RecordScore;


    // Start is called before the first frame update
    void Start()
    {
        RecordScore = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RecordScore += Time.deltaTime;
        Text_Score.text = RecordScore.ToString("0");
    }
}

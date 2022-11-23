using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [SerializeField] float RotateSpeed,MoveSpeed;
    public Score SaveScore;
    public Menu MenuScript;

    private Rigidbody rb;

    private float PlayerSpeed;
    private int CurrentScore;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        PlayerSpeed = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        transform.Rotate(0, 0, RotateSpeed);
        rb.velocity = new Vector3(0, 0, PlayerSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Obstacle"))
        {
            //Save_Score();
            //SceneManager.LoadScene(0);
        }
    }

    private void Save_Score()
    {
        CurrentScore = (int)SaveScore.RecordScore;
        if(CurrentScore > MenuScript.ScoreArray[4])
        {
            MenuScript.ScoreArray[4] = CurrentScore;
            PlayerPrefs.SetInt("Score"+4, CurrentScore);
        }
    }
}

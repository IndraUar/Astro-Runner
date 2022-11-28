using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Main player controller that controls all the actions

public class PlayerController : MonoBehaviour
{
    [Header("Gameobjects")]
    [SerializeField] GameObject ExplosionParticle;
    [SerializeField] GameObject SlimeParticle;
    [SerializeField] Score score_script;

    [Header("Panels")]
    [SerializeField] GameObject LosePanel;
    [SerializeField] GameObject ScoreText;
    [SerializeField] GameObject PauseIcon;
    [SerializeField] GameObject LeftButton;
    [SerializeField] GameObject RightButton;

    [Header("Stats")]
    [SerializeField] float forwardMoveSpeed = 10f;
    [SerializeField] float sideMoveSpeed = 10f;
    [SerializeField] float speedOverTime;
    [SerializeField] float RespawnDelay = 0.2f;
    [SerializeField] float Alien_Score = 50f;

    private Rigidbody rb;
    private Animator animator;

    private float x, y, z;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    public void MoveLeft()
    {
        transform.position -= new Vector3 (0f, 0f, 0.6f);
        if(transform.position.z <= -1.3f)
        {
            transform.position = new Vector3(0f, 0f, -1.2f);
        }
    }

    public void MoveRight()
    {
        transform.position += new Vector3(0f, 0f, 0.6f);
        if (transform.position.z >= 1.3f)
        {
            transform.position = new Vector3(0f, 0f, 1.2f);
        }
    }

    void FixedUpdate()
    {
        //increase the speed overtime
        speedOverTime += 0.2f * Time.deltaTime;

        // I changed the movement from my(Indra) script to fit with the main game from (Choo) because its going sideways..
        x = Input.GetAxis("Horizontal") * (sideMoveSpeed + speedOverTime);
        y = 0f;
        z = (forwardMoveSpeed + speedOverTime) * Time.deltaTime * 50f;

        rb.velocity = new Vector3(z, y, x);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void EnableLosePanel()
    {
        LosePanel.SetActive(true);
        PauseIcon.SetActive(false);
        ScoreText.SetActive(false);
        LeftButton.SetActive(false);
        RightButton.SetActive(false);
    }

    void SetTimeScale()
    {
        Time.timeScale = 0.0f;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            print("Game Over");
            Instantiate(ExplosionParticle, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);

            rb.isKinematic = false;
            
            animator.SetBool("IsDead", true);

            Invoke(nameof(SetTimeScale), 0.6f);
            Invoke(nameof(EnableLosePanel), 0.5f);
        }

        if(collision.gameObject.CompareTag("Alien"))
        {
            Instantiate(SlimeParticle, transform.position, Quaternion.identity);
            score_script.RecordScore += Alien_Score;
            Destroy(collision.gameObject);
        }
    }
}

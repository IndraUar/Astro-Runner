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

    [Header("Audio")]
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip explosionClip;
    [SerializeField] AudioClip CoinClip;

    private Rigidbody rb;
    private Animator animator;

    private float x, y, z;

    [SerializeField] float moveDistance;

    public bool isCollided;
    [SerializeField] LeftButton left;
    [SerializeField] RightButton right;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        isCollided = false;
    }

    public void MoveLeft()
    {
        if(transform.position.z > -1.19f)
        {
            transform.position -= new Vector3(0f, 0f, moveDistance); //0.6f
        }
    }

    public void MoveRight()
    {
        if(transform.position.z < 1.19f)
        {
            transform.position += new Vector3(0f, 0f, moveDistance);
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

        if(left.isPressedLeft == true)
        {
            MoveLeft();
        }
        else if(right.isPressedRight == true)
        {
            MoveRight();
        }
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
            source.PlayOneShot(explosionClip, 1f);
            isCollided = true;
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
            source.PlayOneShot(CoinClip, 1f);
            Instantiate(SlimeParticle, transform.position, Quaternion.identity);
            score_script.RecordScore += Alien_Score;
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// We are using this script for the game
public class PlayerController : MonoBehaviour
{
    [Header("Gameobjects")]
    [SerializeField] GameObject ExplosionParticle;
    [SerializeField] GameObject SlimeParticle;
    [SerializeField] GameObject LosePanel;
    [SerializeField] Score score_script;
    private Rigidbody rb;
    private Animator animator;

    [Header("Stats")]
    [SerializeField] float forwardMoveSpeed = 10f;
    [SerializeField] float sideMoveSpeed = 10f;
    [SerializeField] float speedOverTime = 0;

    [SerializeField] float RespawnDelay = 0.2f;

    private float Alien_Score = 50f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //increase the speed overtime
        speedOverTime += 0.15f * Time.deltaTime;

        // THis is gonna be confusing.. but im changing my script to fit with your game bcz its going sideways lol... 
        float x = Input.GetAxis("Horizontal") * (sideMoveSpeed + speedOverTime);
        float y = 0f;
        float z = (forwardMoveSpeed + speedOverTime) * Time.deltaTime * 50f;

        rb.velocity = new Vector3(z, y, x);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void EnableLosePanel()
    {
        LosePanel.SetActive(true);
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

            rb.isKinematic = true;
            animator.SetBool("IsDead", true);

            Invoke(nameof(SetTimeScale), 0.7f);
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

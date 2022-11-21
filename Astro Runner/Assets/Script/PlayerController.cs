using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This is from my project... For TESTING
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float forwardMoveSpeed = 10f;
    [SerializeField] float sideMoveSpeed = 10f;
    [SerializeField] float speedOverTime = 0;

    [SerializeField] float RespawnDelay = 0.2f;

    void Start()
    {
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

        rb.velocity = new Vector3(-z, y, x);
    }

    void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            print("Game Over");

            // Change Player color when hit obstacle
            //GetComponent<MeshRenderer>().material.color = Color.grey;

            // Reset the level after a while
            Invoke("ResetLevel", RespawnDelay);

            // Stop player from moving after hitting obstacle
            rb.isKinematic = true;

            // Destroy the player 
            //Destroy(gameObject, 0.05f);
        }
    }
}

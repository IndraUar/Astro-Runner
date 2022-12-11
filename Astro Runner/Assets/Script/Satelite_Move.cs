using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To move the satelite

public class Satelite_Move : MonoBehaviour
{
    [SerializeField] private float ObstacleMoveSpeed;
    [SerializeField] Obstacle_Spawn Obstacle_Spawn;

    private PlayerController playerController;
    private GameObject Character;

    private void Start()
    {
        Character = GameObject.Find("Player");
        playerController = Character.GetComponent<PlayerController>();
        Obstacle_Spawn = FindObjectOfType<Obstacle_Spawn>();
    }

    void Update()
    {

        this.transform.position = this.transform.position + new Vector3((ObstacleMoveSpeed + Obstacle_Spawn.speedOverTime) * Time.deltaTime, 0, 0);
        if (playerController.isCollided == true)
        {
            ObstacleMoveSpeed = 0.0f;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("DestroyTag"))
        {
            Destroy(gameObject);
        }
    }
}

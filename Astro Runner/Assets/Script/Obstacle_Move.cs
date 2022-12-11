using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To move the obstacles (Rocks)

public class Obstacle_Move : MonoBehaviour
{
    [SerializeField] private float ObstacleMoveSpeed;
    [SerializeField] Obstacle_Spawn Obstacle_Spawn;

    private PlayerController playerController;
    private GameObject Character;

    void Start()
    {
        float ranScaleY = Random.Range(30f, 70f);
        float ranRotateY = Random.Range(0f, 180f);

        this.transform.localScale = new Vector3(this.transform.localScale.x, ranScaleY, this.transform.localScale.z);
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, ranRotateY, this.transform.rotation.y);
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

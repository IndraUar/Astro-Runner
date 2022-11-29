using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To move the obstacles (Rocks)

public class Obstacle_Move : MonoBehaviour
{
    [SerializeField] private float ObstacleMoveSpeed;
    public float speedOverTime;
    private GameObject Character;
    private PlayerController playerController;

    void Start()
    {
        float ranScaleY = Random.Range(30f, 70f);
        float ranRotateY = Random.Range(0f, 180f);

        this.transform.localScale = new Vector3(this.transform.localScale.x, ranScaleY, this.transform.localScale.z);
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, ranRotateY, this.transform.rotation.y);
        Character = GameObject.Find("Player");
        playerController = Character.GetComponent<PlayerController>();
    }

    void Update()
    {
        speedOverTime += 0.2f * Time.deltaTime;
        this.transform.position = this.transform.position + new Vector3((ObstacleMoveSpeed + speedOverTime) * Time.deltaTime, 0, 0);
        if (playerController.isCollided == true)
        {
            ObstacleMoveSpeed = 0.0f;
            speedOverTime = 0.0f;
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

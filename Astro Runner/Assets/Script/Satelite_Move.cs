using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To move the satelite

public class Satelite_Move : MonoBehaviour
{
    [SerializeField] private float ObstacleMoveSpeed;
    public float speedOverTime;

    private GameObject Character;
    private PlayerController playerController;
    private void Start()
    {
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

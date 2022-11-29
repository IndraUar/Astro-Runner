using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien_Move : MonoBehaviour
{
    [SerializeField] private float AlienMoveSpeed;

    private GameObject Character;
    private PlayerController playerController;

    private void Start()
    {
        Character = GameObject.Find("Player");
        playerController = Character.GetComponent<PlayerController>();
    }

    void Update()
    {
        this.transform.position = this.transform.position + new Vector3(AlienMoveSpeed * Time.deltaTime, 0, 0);
        if (playerController.isCollided == true)
        {
            AlienMoveSpeed = 0.0f;
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

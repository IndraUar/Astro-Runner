using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To move the platform

public class Platform_Move : MonoBehaviour
{
    [SerializeField] private float PlatformMoveSpeed;
    public Vector3 stopp;

    private GameObject Character;
    private PlayerController playerController;

    private void Start()
    {
        Character = GameObject.Find("Player");
        playerController = Character.GetComponent<PlayerController>();
    }
    void Update()
    {
        if (playerController.isCollided == true)
        {
            PlatformMoveSpeed = 0.0f;
        }
        this.transform.position = this.transform.position + new Vector3(PlatformMoveSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("DestroyTag"))
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotation : MonoBehaviour
{
    public float rotateSpeed = 50f;

    private GameObject Character;
    private PlayerController playerController;
    private void Start()
    {
        Character = GameObject.Find("Player");
        playerController = Character.GetComponent<PlayerController>();
    }

    void Update()
    {
        transform.Rotate(new Vector3 (0, 0, -rotateSpeed) * Time.deltaTime);
        if (playerController.isCollided == true)
        {
            rotateSpeed = 0.0f;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To move the platform

public class Platform_Move : MonoBehaviour
{
    [SerializeField] private float PlatformMoveSpeed;

    void Update()
    {
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

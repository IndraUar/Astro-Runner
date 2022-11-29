using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To move the satelite

public class Satelite_Move : MonoBehaviour
{
    [SerializeField] private float ObstacleMoveSpeed;
    public float speedOverTime;

    void Update()
    {
        speedOverTime += 0.2f * Time.deltaTime;

        this.transform.position = this.transform.position + new Vector3((ObstacleMoveSpeed + speedOverTime) * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("DestroyTag"))
        {
            Destroy(gameObject);
        }
    }
}

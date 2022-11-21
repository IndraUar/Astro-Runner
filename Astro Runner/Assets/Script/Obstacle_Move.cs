using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Move : MonoBehaviour
{
    [SerializeField] private float ObstacleMoveSpeed;

    void Update()
    {
        this.transform.position = this.transform.position + new Vector3(ObstacleMoveSpeed * Time.deltaTime, 0, 0);
    }
}

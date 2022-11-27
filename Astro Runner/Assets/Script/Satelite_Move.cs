using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satelite_Move : MonoBehaviour
{
    [SerializeField] private float ObstacleMoveSpeed;
    public float speedOverTime;

    void Update()
    {
        speedOverTime += 0.2f * Time.deltaTime;

        this.transform.position = this.transform.position + new Vector3((ObstacleMoveSpeed + speedOverTime) * Time.deltaTime, 0, 0);
    }
}

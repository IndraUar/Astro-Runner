using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Move : MonoBehaviour
{
    [SerializeField] private float ObstacleMoveSpeed;
    public float speedOverTime;

    void Start()
    {
        float ranScaleY = Random.Range(30f, 70f);
        float ranRotateY = Random.Range(0f, 180f);
        this.transform.localScale = new Vector3(this.transform.localScale.x, ranScaleY, this.transform.localScale.z);
        this.transform.rotation = Quaternion.EulerAngles(this.transform.rotation.x, ranRotateY, this.transform.rotation.y);
    }

    void Update()
    {
        speedOverTime += 0.2f * Time.deltaTime;

        this.transform.position = this.transform.position + new Vector3((ObstacleMoveSpeed + speedOverTime) * Time.deltaTime, 0, 0);
    }
}

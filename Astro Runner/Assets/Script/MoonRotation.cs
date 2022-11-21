using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotation : MonoBehaviour
{
    public float rotateSpeed = 50f;
    void Update()
    {
        transform.Rotate(new Vector3 (0, 0, -rotateSpeed) * Time.deltaTime);
    }
}

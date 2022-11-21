using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Move : MonoBehaviour
{
    [SerializeField] private float PlatformMoveSpeed;

    void Update()
    {
        this.transform.position = this.transform.position + new Vector3(PlatformMoveSpeed * Time.deltaTime, 0, 0);
    }
}

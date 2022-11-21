using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Vector3 Offset = new Vector3(0, 6.6f, -7);
    [SerializeField] float CameraOffsetAngel = 35f;

    void Update()
    {
        if (Player != null)
        {
            transform.SetPositionAndRotation(Player.position + Offset, Quaternion.Euler(CameraOffsetAngel, 0, 0));
        }
    }
}

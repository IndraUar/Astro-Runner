using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    [SerializeField] Transform PlayerCharacter;
    [SerializeField] Vector3 Offset;

    void Update()
    {
        if(PlayerCharacter != null)
        {
            transform.position = PlayerCharacter.transform.position + Offset;
            transform.LookAt(PlayerCharacter);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien_Move : MonoBehaviour
{
    [SerializeField] private float AlienMoveSpeed;
    void Update()
    {
        this.transform.position = this.transform.position + new Vector3(AlienMoveSpeed * Time.deltaTime, 0, 0);
    }
}

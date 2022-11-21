using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Spawn : MonoBehaviour
{
    [SerializeField] GameObject PrefabPlatform;
    [SerializeField] Transform SpawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            var platform = Instantiate(PrefabPlatform, SpawnPoint.transform.position, Quaternion.identity);
            platform.tag = "Platform";
        }
    }
}
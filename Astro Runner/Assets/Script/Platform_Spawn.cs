using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Spawn : MonoBehaviour
{
    [SerializeField] GameObject PrefabPlatform;
    [SerializeField] Transform SpawnPoint;
    [SerializeField] float spawntime;

    private float currentTime;
    private void FixedUpdate()
    {
        if(currentTime >= spawntime)
        {
            Invoke("SpawnPlatform", 0);
            currentTime = 0;
        }
        currentTime += Time.deltaTime;
    }
    void SpawnPlatform()
    {
        var platform = Instantiate(PrefabPlatform, SpawnPoint.transform.position, Quaternion.identity);
        platform.tag = "Platform";
    }
}
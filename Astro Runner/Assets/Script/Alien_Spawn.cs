using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien_Spawn : MonoBehaviour
{
    [SerializeField] GameObject PrefabAlien;
    [SerializeField] Transform[] SpawnPoint;

    [SerializeField] int Max_spawnCount, Max_Spawn_Interval_Time, Min_Spawn_Interval_Time;

    private Vector3 SpawnPosition;
    private float SpawnInterval;

    private int Position;

    void Update()
    {

        if (SpawnInterval <= 0)
        {
            Position = Random.Range(0, 5);
            SpawnPosition = SpawnPoint[Position].transform.position;
            var obstacle = Instantiate(PrefabAlien, SpawnPosition, Quaternion.identity);
            obstacle.tag = "Alien";
            SpawnInterval = Random.Range(Min_Spawn_Interval_Time, Max_Spawn_Interval_Time + 1);
        }
        else
        {
            SpawnInterval -= Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien_Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] PrefabAlien;
    [SerializeField] Transform[] SpawnPoint;

    [SerializeField] int Max_spawnCount, Max_Spawn_Interval_Time, Min_Spawn_Interval_Time;

    private Vector3 SpawnPosition;
    private float SpawnInterval;

    private int Position;
    private int RanAlien;

    void Update()
    {

        if (SpawnInterval <= 0)
        {
            Position = Random.Range(0, 5);
            RanAlien = Random.Range(0, PrefabAlien.Length);
            SpawnPosition = SpawnPoint[Position].transform.position;
            var obstacle = Instantiate(PrefabAlien[RanAlien], SpawnPosition, Quaternion.EulerAngles(0f, 90f, 0f));
            obstacle.tag = "Alien";
            SpawnInterval = Random.Range(Min_Spawn_Interval_Time, Max_Spawn_Interval_Time + 1);
        }
        else
        {
            SpawnInterval -= Time.deltaTime;
        }
    }
}

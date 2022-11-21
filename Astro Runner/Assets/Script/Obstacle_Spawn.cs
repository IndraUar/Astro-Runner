using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawn : MonoBehaviour
{
    [SerializeField] GameObject PrefabObstacle;
    [SerializeField] Transform[] SpawnPoint;
    [SerializeField] int Max_spawnCount, Max_Spawn_Interval_Time, Min_Spawn_Interval_Time;

    private Vector3 SpawnPosition;
    private int SpawnCount;
    private float SpawnInterval;

    private int Position;
    private bool[] ArrayPosition;


    //Instantiate(PrefabPlatform, SpawnPoint.transform.position, Quaternion.identity);
    private void Start()
    {
        ArrayPosition = new bool[5];
    }

    private void FixedUpdate()
    {
        float RanY = Random.Range(-360f, 360); 

        if(SpawnInterval <=0)
        {
            SpawnCount = Random.Range(1, Max_spawnCount);
            for (int i = 0; i < SpawnCount; i++)
            {
                do
                {
                    Position = Random.Range(0, 5);
                } while (ArrayPosition[Position] != false);

                SpawnPosition = SpawnPoint[Position].transform.position;
                ArrayPosition[Position] = true;
                var obstacle = Instantiate(PrefabObstacle, SpawnPosition, Quaternion.identity);
                //var obstacle = Instantiate(PrefabObstacle, SpawnPosition, Quaternion.EulerRotation(0f, RanY, 0f)); // for random rotation
                obstacle.tag = "Obstacle";
            }
            for (int j = 0; j < 5; j++)
            {
                ArrayPosition[j] = false;
            }
            SpawnInterval = Random.Range(Min_Spawn_Interval_Time, Max_Spawn_Interval_Time+1);
        }
        else
        {
            SpawnInterval -= Time.deltaTime;
        }
    }
}

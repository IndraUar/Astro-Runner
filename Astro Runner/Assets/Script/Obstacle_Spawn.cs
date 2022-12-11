using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawn : MonoBehaviour
{
    [SerializeField] GameObject[] PrefabObstacle;
    [SerializeField] Transform[] SpawnPoint;
    [SerializeField] int Max_spawnCount;
    [SerializeField] float Max_Spawn_Interval_Time, Min_Spawn_Interval_Time;

    [SerializeField] PlayerController playerController;

    private Vector3 SpawnPosition;
    private int SpawnCount;
    private float SpawnInterval;

    private int Position;
    private bool[] ArrayPosition;
    public float speedOverTime;

    private void Start()
    {
        ArrayPosition = new bool[5];
    }

    private void FixedUpdate()
    {
        speedOverTime += 0.01f * Time.deltaTime;

        if (playerController.isCollided == true)
        {
            speedOverTime = 0.0f;
        }

        int ranObstacle = Random.Range(0, PrefabObstacle.Length);

        if(SpawnInterval <=0)
        {
            SpawnCount = Random.Range(1, Max_spawnCount);
            for (int i = 0; i < SpawnCount; i++)
            {
                do
                {
                    Position = Random.Range(0, SpawnPoint.Length);
                } while (ArrayPosition[Position] != false);

                SpawnPosition = SpawnPoint[Position].transform.position;
                ArrayPosition[Position] = true;
                var obstacle = Instantiate(PrefabObstacle[ranObstacle], SpawnPosition, Quaternion.identity);
                obstacle.tag = "Obstacle";
            }
            for (int j = 0; j < 5; j++)
            {
                ArrayPosition[j] = false;
            }
            SpawnInterval = Random.Range(Min_Spawn_Interval_Time, Max_Spawn_Interval_Time + 1 - (speedOverTime / 3f));
        }
        else
        {
            SpawnInterval -= Time.deltaTime;
        }
    }
}

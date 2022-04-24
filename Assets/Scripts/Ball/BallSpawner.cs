using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject yellowBall, orangeBall, redBall, purpleBall, spikeBall;

    private float distance;
    private float distanceUsed;
    private float rangeDist = 50;

    private void Update()
    {
        if (Mathf.Abs(distance) < Mathf.Abs(transform.position.x) + rangeDist){
            if(transform.position.x < 0){
                distance = transform.position.x - rangeDist;
            }
            else{
                distance = transform.position.x + rangeDist;
            }
        }
        float distToGo = Mathf.Floor(Mathf.Abs(distance) - Mathf.Abs(distanceUsed));

        if (Mathf.Abs(distanceUsed) < Mathf.Abs(distance) && distToGo > 4){
            distanceUsed = distance;
            SpawnBall();
        }
    }

    private void SpawnBall()
    {
        GameObject ballToSpawn = yellowBall;

        float yPos = Mathf.Floor(
            Mathf.Abs(UnityEngine.Random.Range(0f, 1f) - UnityEngine.Random.Range(0f, 1f)) * 
            (1 + 100 - (-2)) + (-2)
            );
        Vector2 posToSpawnBall = new Vector2(distance, yPos);

        Instantiate(ballToSpawn, posToSpawnBall, Quaternion.identity);
    }
}

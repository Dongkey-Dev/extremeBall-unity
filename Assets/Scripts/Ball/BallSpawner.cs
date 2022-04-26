using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public List<GameObject> spawnPool;
    public GameObject quad;
    private float distance;
    private float distanceUsed;
    private float rangeDist = 50;
    private int numberToSpawn = 10;

    private void Start()
    {
        spawnBallWithQuad();
    }

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
        int randomItem;
        randomItem = Random.Range(0, spawnPool.Count);
        GameObject ballToSpawn = spawnPool[randomItem];

        float yPos = Mathf.Floor(
            Random.Range(transform.position.y + 30, transform.position.y - 30)
            // Mathf.Abs(UnityEngine.Random.Range(0f, 1f) - UnityEngine.Random.Range(0f, 1f)) * 
            // (1 + 100 - (-2)) + (-2)
            );
        Vector2 posToSpawnBall = new Vector2(distance, yPos);

        Instantiate(ballToSpawn, posToSpawnBall, Quaternion.identity);
    }

    public void spawnBallWithQuad(){
        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider mc = quad.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        for(int i = 0; i < numberToSpawn; i++){
            randomItem = Random.Range(0, spawnPool.Count);
            toSpawn = spawnPool[randomItem];

            screenX = Random.Range(mc.bounds.min.x, mc.bounds.max.x);
            screenY = Random.Range(mc.bounds.min.y, mc.bounds.max.y);
            pos = new Vector2(screenX, screenY);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }    
}

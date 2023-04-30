using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public List<GameObject> spawnPool;
    public GameObject quad;
    private float distancePlus;
    private float distanceMinus;
    private float distanceMinusUsed;
    private float distancePlusUsed;
    private float rangeDist = 50;
    private int numberToSpawn = 10;

    private void Start()
    {
        spawnBallWithQuad();
    }

    private void Update()
    {
        if (transform.position.x < 0){
            distanceMinus = transform.position.x - rangeDist;
            float distToGo = Mathf.Floor(Mathf.Abs(distanceMinus) - Mathf.Abs(distanceMinusUsed));
            if (Mathf.Abs(distanceMinusUsed) < Mathf.Abs(distanceMinus) && distToGo > 4){
                distanceMinusUsed = distanceMinus;
                SpawnBall(distanceMinus);
            }
        }
        else {
            distancePlus = transform.position.x + rangeDist;
            float distToGo = Mathf.Floor(Mathf.Abs(distancePlus) - Mathf.Abs(distancePlusUsed));
            if (Mathf.Abs(distancePlusUsed) < Mathf.Abs(distancePlus) && distToGo > 4){
                distancePlusUsed = distancePlus;
                SpawnBall(distancePlus);
            }
        }
    }

    private void SpawnBall(float distance)
    {
        int randomItem;
        randomItem = Random.Range(0, spawnPool.Count);
        GameObject ballToSpawn = spawnPool[randomItem];

        float yPos = Mathf.Floor(
            Random.Range(transform.position.y + 30, transform.position.y - 30)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSpawner : MonoBehaviour
{
    public int numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject quad;
    private string yellow_score = "yellow_score";
    private string orange_score = "orange_score";
    private string red_score = "red_score";
    private string purple_score = "purple_score";
    private string spike_ball = "spike_ball";

    void Start()
    {
        spawnObjects();
    }
    public void spawnObjects(){
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

    private void DestroyObjects(){
        DestroyObjectsBall(new []{
            yellow_score, 
            orange_score, 
            spike_ball, 
            purple_score, 
            red_score});
    }
    private void DestroyObjectsBall(string[] balls){
        foreach(string ball in balls){
            foreach(GameObject o in GameObject.FindGameObjectsWithTag(ball)){
                Destroy(o);
            }            
        }
    }
}

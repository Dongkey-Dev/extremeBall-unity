using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Gameover gameover;
    public ScoreScript scorescript;
    public void GameOver(){
        int end_score = scorescript.GetScoreNum(); 
        Debug.Log(end_score);
        gameover.Setup(end_score);
    }
}
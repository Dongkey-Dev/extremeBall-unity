using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Gameover gameover;
    public ScoreScript scorescript;
    public void GameOver(){
        StartCoroutine(GameOverAfterDelay());
    }
    private IEnumerator GameOverAfterDelay(){
        yield return new WaitForSeconds(.5f);
        int end_score = scorescript.GetScoreNum(); 
        gameover.Setup(end_score);
    }
}

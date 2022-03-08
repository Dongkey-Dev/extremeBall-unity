using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Gameover gameover;
    int end_score;
    public void GameOver(){
        gameover.Setup(end_score);
    }
}

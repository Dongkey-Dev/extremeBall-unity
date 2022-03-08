using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Gameover gameover;
    public void GameOver(int end_score){
        end_score = 0;
        gameover.Setup(end_score);
    }
}

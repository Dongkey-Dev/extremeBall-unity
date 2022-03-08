using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text MyscoreText;
    private int ScoreNum;
    public GameController gamecontroller;

    public int GetScoreNum(){
        return ScoreNum;
    }

    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0; 
        MyscoreText.text = "Score : " + ScoreNum;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D score)
    {
        if(score.tag == "yellow_score"){
            ScoreNum += 100;
            Destroy(score.gameObject);
            MyscoreText.text = "Score : " + ScoreNum;
            playerStatus.currentHP = Mathf.Min(playerStatus.currentHP+30, playerStatus.maxHP);
        }
        else if(score.tag == "orange_score"){
            ScoreNum += 300;
            Destroy(score.gameObject);
            MyscoreText.text = "Score : " + ScoreNum;
            playerStatus.currentHP = playerStatus.maxHP;
        }        
        else if(score.tag == "red_ball"){
            playerStatus.currentHP = 0.0f;
        }        
    }
}

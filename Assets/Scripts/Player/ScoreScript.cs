using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text MyscoreText;
    private int ScoreNum;

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
            playerStatus.currentHP = playerStatus.maxHP;
        }
        if(score.tag == "green_ball"){
            playerStatus.currentHP = 0.0f;
        }        
    }
}

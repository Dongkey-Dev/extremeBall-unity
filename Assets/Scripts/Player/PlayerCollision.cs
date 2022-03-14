using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public Text MyscoreText;
    private int ScoreNum;
    public ParticleSystem ps;
    public ParticleSystem.MainModule ps_main;
    
    public int GetScoreNum(){
        return ScoreNum;
    }
    void Start()
    {
        ScoreNum = 0; 
        MyscoreText.text = "Score : " + ScoreNum;
        ps_main = ps.main;
    }

    private void OnTriggerEnter2D(Collider2D score)
    {
        if(score.tag == "yellow_score"){
            ScoreNum += 100;
            MyscoreText.text = "Score : " + ScoreNum;
            ExplodeScore(score.transform.position, score.transform.rotation);
            Destroy(score.gameObject);
            playerStatus.currentHP = Mathf.Min(playerStatus.currentHP+50, playerStatus.maxHP);
            SoundManagerScript.playSound("scoreBallSound");
        }
        else if(score.tag == "orange_score"){
            ScoreNum += 300;
            MyscoreText.text = "Score : " + ScoreNum;
            ExplodeScore(score.transform.position, score.transform.rotation);
            Destroy(score.gameObject);            
            playerStatus.currentHP = playerStatus.maxHP;
            SoundManagerScript.playSound("scoreBallSound");
        }        
        else if(score.tag == "red_ball" | score.tag == "Lava"){
            playerStatus.currentHP = 0.0f;
        }
        CameraShake.Instance.ShakeCamera(10f, .2f);
    }

    void ExplodeScore(Vector3 pos, Quaternion rot)
    {
        ps_main.startSpeed = ShootToMouse.PlayerVelocity.magnitude;
        Instantiate(ps, pos, rot);
    }
}

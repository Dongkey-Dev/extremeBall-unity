using System.Net.Sockets;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public int YScore=100;
    public int OScore=300;
    public int PScore=300;
    public int RScore=300;
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

    private void changeScoreByCondition(Collider2D score)
    {
        
        void changeScore(int s, string c, float chp){
            ScoreNum += s;
            MyscoreText.text = "Score : " + ScoreNum;
            ExplodeScore(c, score.transform.position, score.transform.rotation);
            Destroy(score.gameObject);
            playerStatus.currentHP = chp;
            SoundManagerScript.playSound("scoreBallSound");
        }

        if(score.tag == "yellow_score"){
            changeScore(YScore, "yellow", Mathf.Min(playerStatus.currentHP+50, playerStatus.maxHP));
        }
        else if(score.tag == "orange_score"){
            changeScore(OScore, "orange", playerStatus.maxHP);
        }        
        else if(score.tag == "purple_score"){
            changeScore(PScore, "purple", playerStatus.maxHP);
        }                
        else if(score.tag == "red_score"){
            changeScore(RScore, "red", playerStatus.maxHP);
        }                        
        else if(score.tag == "spike_ball" | score.tag == "Lava"){
            playerStatus.currentHP = 0.0f;
        }
        CameraShake.Instance.ShakeCamera(10f, .2f);
    }

    private void OnTriggerEnter2D(Collider2D score)
    {
        changeScoreByCondition(score);
    }

    public void ExplodeScore(string color, Vector3 pos, Quaternion rot)
    {
        ps_main.startSpeed = ShootToMouse.PlayerVelocity.magnitude;
        switch(color)
        {
            // enum
            case "yellow":      
                ps_main.startColor = new ParticleSystem.MinMaxGradient(
                    new Vector4(1,(float)246/255,(float)187/255,1), 
                    new Vector4((float)255/255,(float)194/255,0,1)
                );
                break;

            case "orange":
                ps_main.startColor = new ParticleSystem.MinMaxGradient(
                    new Vector4(1,(float)215/255,(float)0/255,1), 
                    new Vector4((float)229/255,(float)121/255,0,1)
                );
                break;

            case "purple":
                ps_main.startColor = new ParticleSystem.MinMaxGradient(
                    new Vector4(1,(float)0/255,(float)124/255,1), 
                    new Vector4((float)123/255,(float)255/255,1,1)
                );
                break;

            case "red":
                ps_main.startColor = new ParticleSystem.MinMaxGradient(
                    new Vector4(1,(float)73/255,(float)0/255,1), 
                    new Vector4((float)255/255,(float)0/255,(float)170/255,1)
                );
                break;          

            case "player":
                ps_main.startColor = new ParticleSystem.MinMaxGradient(
                    new Vector4(0,0,0,1),
                    new Vector4(1,1,1,1)
                );
                break;                    
        }
        Instantiate(ps, pos, rot);
    }
}

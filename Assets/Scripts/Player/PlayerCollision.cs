using System.Net.Sockets;
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
            ExplodeScore("yellow",score.transform.position, score.transform.rotation);
            Destroy(score.gameObject);
            playerStatus.currentHP = Mathf.Min(playerStatus.currentHP+50, playerStatus.maxHP);
            SoundManagerScript.playSound("scoreBallSound");
        }
        else if(score.tag == "orange_score"){
            ScoreNum += 300;
            MyscoreText.text = "Score : " + ScoreNum;
            ExplodeScore("orange", score.transform.position, score.transform.rotation);
            Destroy(score.gameObject);            
            playerStatus.currentHP = playerStatus.maxHP;
            SoundManagerScript.playSound("scoreBallSound");
        }        
        else if(score.tag == "purple_score"){
            ScoreNum += 300;
            MyscoreText.text = "Score : " + ScoreNum;
            ExplodeScore("purple",score.transform.position, score.transform.rotation);
            Destroy(score.gameObject);            
            playerStatus.currentHP = playerStatus.maxHP;
            SoundManagerScript.playSound("scoreBallSound");
        }                
        else if(score.tag == "red_score"){
            ScoreNum += 300;
            MyscoreText.text = "Score : " + ScoreNum;
            ExplodeScore("red",score.transform.position, score.transform.rotation);
            Destroy(score.gameObject);            
            playerStatus.currentHP = playerStatus.maxHP;
            SoundManagerScript.playSound("scoreBallSound");
        }                        
        else if(score.tag == "spike_ball" | score.tag == "Lava"){
            playerStatus.currentHP = 0.0f;
        }
        CameraShake.Instance.ShakeCamera(10f, .2f);
    }

    public Gradient getGradient(Color c1, Color c2)
    {
        Gradient gradient = new Gradient();
 
        GradientColorKey[] gradientColors = new GradientColorKey[2];
        gradientColors[0].color = c1;
        gradientColors[1].color = c2;
        gradientColors[0].time = 0f;
        gradientColors[1].time = 1f;
 
        GradientAlphaKey[] gradientAlpha = new GradientAlphaKey[2];
        gradientAlpha[0].alpha = 1;
        gradientAlpha[0].time = 0;
        gradientAlpha[1].alpha = 1;
        gradientAlpha[1].time = 1f ;
 
        gradient.SetKeys(gradientColors, gradientAlpha);
        return gradient;
    }    

    void ExplodeScore(string color, Vector3 pos, Quaternion rot)
    {
        ps_main.startSpeed = ShootToMouse.PlayerVelocity.magnitude;
        switch(color)
        {
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
        }
        Instantiate(ps, pos, rot);
    }
}

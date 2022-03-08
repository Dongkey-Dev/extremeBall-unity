using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStatus : MonoBehaviour
{
    public static float maxHP;
    public static float currentHP;
    public GameController gamecontroller;
    void Start(){
        maxHP = 200.0f;
        currentHP = 200.0f;
    }
    void FixedUpdate(){
        if(this.transform.position.x >= 1050 ){
            this.transform.position = new Vector3(-1050,this.transform.position.y, this.transform.position.z);
        } else if(this.transform.position.x <= -1050 ){
            this.transform.position = new Vector3(1050,this.transform.position.y, this.transform.position.z);
        }
        if(this.transform.position.y <= -4.7){
            currentHP = 0;
        }
        if(currentHP <= 0.0f){
            Destroy(this.gameObject);
            gamecontroller.GameOver();
        } 
        if(Input.GetMouseButton(0)){
            currentHP -= 1.0f;
        }
        else{
            currentHP -= 0.2f;
        }
    }
}
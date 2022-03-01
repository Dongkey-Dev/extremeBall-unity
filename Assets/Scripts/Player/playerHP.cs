using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHP : MonoBehaviour
{
    public static float maxHP;
    public static float currentHP;
    // Start is called before the first frame update
    void Start(){
        maxHP = 200.0f;
        currentHP = 200.0f;
    }
    void FixedUpdate(){
        if(currentHP <= 0.0f){
            Destroy(this.gameObject);
        } 
        if(Input.GetMouseButton(0)){
            currentHP -= 0.5f;
        }
        else{
            currentHP -= 0.2f;
        }
    }
}

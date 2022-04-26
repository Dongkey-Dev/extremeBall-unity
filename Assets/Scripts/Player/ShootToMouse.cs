using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShootToMouse : MonoBehaviour
{
    float lastSpeed;
    public int force;
    public static Vector3 PlayerVelocity;
    Vector3 posInScreen;
    void Start(){
        force = 2;
    }
    void Update(){
        PlayerVelocity = GetComponent<Rigidbody2D>().velocity;
        if (Input.GetMouseButtonUp(0)){
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            posInScreen = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dirToMouse = Input.mousePosition - posInScreen;
            float distance = Vector3.Distance(posInScreen, Input.mousePosition); 
            dirToMouse.Normalize();
            distance = Mathf.Max(400, distance * force);
            GetComponent<Rigidbody2D>().AddForce(dirToMouse * distance);
            SoundManagerScript.playSound("playerJumpSound");
        }
    }
    private void OnTriggerEnter2D(Collider2D score)
    {
        if(score.tag == "yellow_score"){
            lastSpeed = GetComponent<Rigidbody2D>().velocity.magnitude;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().AddForce((new Vector3(Random.Range(-50,50), 80, 0)) * lastSpeed/4);
        }
        else if(score.tag == "orange_score"){
            lastSpeed = GetComponent<Rigidbody2D>().velocity.magnitude;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().AddForce((new Vector3(Random.Range(-300,300), Random.Range(-100,100), 0)) * lastSpeed/3);
        }
        else if(score.tag == "red_score"){
            lastSpeed = GetComponent<Rigidbody2D>().velocity.magnitude;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().AddForce((new Vector3(Random.Range(-300,300), Random.Range(-100,100), 0)) * (float)lastSpeed/1.5f);
        }        
    }    
}

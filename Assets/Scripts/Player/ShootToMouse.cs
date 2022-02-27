using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ShootToMouse : MonoBehaviour
{
    float lastSpeed;
    public static Vector3 PlayerVelocity;
    public static Vector3 PlayerPosition;

    void Start(){
        PlayerPosition = GetComponent<Rigidbody2D>().position;
    }
    Vector3 posInScreen;
    void Update(){
        PlayerVelocity = GetComponent<Rigidbody2D>().velocity;
        PlayerPosition = GetComponent<Rigidbody2D>().position;
        if (Input.GetMouseButtonUp(0)){
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            posInScreen = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dirToMouse = Input.mousePosition - posInScreen;
            float distance = Vector3.Distance(posInScreen, Input.mousePosition); 
            dirToMouse.Normalize();
            distance = Mathf.Max(200, distance);
            GetComponent<Rigidbody2D>().AddForce(dirToMouse * distance * 6);
        }
    }
    private void OnTriggerEnter2D(Collider2D score)
    {
        if(score.tag == "Myscore"){
            lastSpeed = GetComponent<Rigidbody2D>().velocity.magnitude;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().AddForce((new Vector3(Random.Range(-50,50), 80, 0)) * lastSpeed/4);
        }
    }    
}

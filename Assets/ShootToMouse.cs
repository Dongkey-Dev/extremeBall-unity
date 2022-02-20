using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToMouse : MonoBehaviour
{
    Vector3 posInScreen;
    void Update(){
        if (Input.GetMouseButtonDown(0)){
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            posInScreen = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dirToMouse = Input.mousePosition - posInScreen;
            float distance = Vector3.Distance(posInScreen, Input.mousePosition);
            dirToMouse.Normalize();
            distance = Mathf.Max(200, distance);
            GetComponent<Rigidbody2D>().AddForce(dirToMouse * distance * 4);
            Debug.Log(posInScreen);
            Debug.Log(Input.mousePosition);
        }
    }
    private void OnTriggerEnter2D(Collider2D score)
    {
        if(score.tag == "Myscore"){
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().AddForce((new Vector3(Random.Range(-10,10), 80, 0)) * 10);
        }
    }    
}

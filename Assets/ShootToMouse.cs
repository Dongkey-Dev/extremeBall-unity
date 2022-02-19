using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToMouse : MonoBehaviour
{
    void Update(){
        if (Input.GetMouseButtonDown(0)){
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Vector3 posInScreen = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dirToMouse = Input.mousePosition - posInScreen;
            float distance = Vector3.Distance(posInScreen, Input.mousePosition);
            dirToMouse.Normalize();
            distance = Mathf.Max(200, distance);
            Debug.Log(distance);
            GetComponent<Rigidbody2D>().AddForce(dirToMouse * distance * 3);
        }
    }
}

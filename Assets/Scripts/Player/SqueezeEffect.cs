using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerMoudle;

public class SqueezeEffect : MonoBehaviour
{   
    Vector3 posInScreen;
    Vector3 orginalScale = new Vector3(1,1,1);
    Vector3 beforeBallPos;
    Vector3 currentBallPos;
    float pressMax = 1000.0f;
    // Start is called before the first frame update
    void Update(){
        if (Input.GetMouseButton(0)){
            Vector3 _currentPosition = pm.GetCurrentMousePosition().GetValueOrDefault();
            Vector3 _initialPosition = transform.position;            
            float distance = GetDistance();
            transform.localScale = orginalScale - new Vector3(10*distance,0,0);
            var degrees = pm.AngleInDeg(_currentPosition, _initialPosition);
            transform.eulerAngles = Vector3.forward * degrees;
        }
        else if (Input.GetMouseButtonUp(0)){
            float distance = GetDistance();
            transform.localScale = orginalScale;
        }
    }

    void FixedUpdate(){
        if (!Input.GetMouseButton(0)){
            currentBallPos = transform.position;
            var degrees = pm.AngleInDeg(beforeBallPos, currentBallPos);
            float distance = Vector3.Distance(beforeBallPos, currentBallPos);
            transform.eulerAngles = Vector3.forward * degrees;
            transform.localScale = orginalScale - new Vector3(0,distance/5,0);   
            beforeBallPos = currentBallPos;
            Debug.Log(distance);
        }
    }
    public float GetDistance(){
        Vector3 _currentPosition = pm.GetCurrentMousePosition().GetValueOrDefault();
        Vector3 _initialPosition = transform.position;
        float distance = Vector3.Distance(_currentPosition, _initialPosition);
        distance = Mathf.Min(pressMax, distance)/2000;  
        return distance;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerMoudle;

public class SqueezeEffect : MonoBehaviour
{   
    Vector3 posInScreen;
    Vector3 orginalScale = new Vector3(1,1,1);
    float pressMax = 1000.0f;
    // Start is called before the first frame update
    void Update(){
        if (Input.GetMouseButton(0)){
            float distance = GetDistance();
            transform.localScale = orginalScale - new Vector3(0,10*distance,0);
            Debug.Log(distance);
        }
        else if (Input.GetMouseButtonUp(0)){
            float distance = GetDistance();
            transform.localScale = orginalScale;
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
